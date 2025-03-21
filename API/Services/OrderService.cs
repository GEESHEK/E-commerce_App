using API.Data;
using API.Data.Repositories;
using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using API.Entities.WatchEntities;
using API.Exceptions;

namespace API.Services;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly IWatchRepository _watchRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerService _customerService;

    public OrderService(DataContext context, IWatchRepository watchRepository, 
        IOrderRepository orderRepository, ICustomerService customerService)
    {
        _context = context;
        _watchRepository = watchRepository;
        _orderRepository = orderRepository;
        _customerService = customerService;
    }
    //add to interface
    public async Task<SuccessOrderDto> PlaceOrder(Order order, List<Watch> watches, int userId)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var totalPrice = await ReduceWatchQuantityAndReturnTotalPrice(watches, order);
            order.Total = totalPrice;
                
            AddPriceToOrderItems(watches, order);

            if (userId > 0)
            {
                // Authenticated user: Update customer details
                order.CustomerDetail.AppUserId = userId;

                var updatedOrder = _customerService.UpdateAndAddCustomerDetailToExistingUser(userId, order);
                
                _orderRepository.CreateOrder(updatedOrder);
                    
                // Save all changes together (stock reduction and order creation)
                if (await _context.SaveChangesAsync() > 0)
                {
                    // Finalize transaction
                    await transaction.CommitAsync();
                        
                    var successOrder = await _orderRepository.GetSuccessOrderById(updatedOrder.Id);
                    
                    if (successOrder == null)
                    {
                        throw new Exception("Order was not found");
                    }
                
                    return successOrder;
                }
                
                throw new Exception("Failed to create order");
            }
                
            // Guest user: Create order without updating customer details
            _orderRepository.CreateOrder(order);
            
            if (await _context.SaveChangesAsync() > 0)
            {
                await transaction.CommitAsync();
                    
                var successOrder = await _orderRepository.GetSuccessOrderById(order.Id);
                
                if (successOrder == null)
                {
                    throw new NotFoundException("Order was not found");
                }

                return successOrder;
            }

            throw new Exception("Failed to create order");
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<decimal> ReduceWatchQuantityAndReturnTotalPrice(List<Watch> watches, Order order)
    {
        var totalPrice = 0m;
        
        if (watches == null || !watches.Any())
        {
            throw new ArgumentException("Watches cannot be null or empty", nameof(watches));
        }

        if (order.Items == null || !order.Items.Any())
        {
            throw new ArgumentException("Items cannot be null or empty", nameof(order));
        }

        var watchesDictionary = order.Items.ToDictionary(item => item.ProductId, item => item.Quantity);

        foreach (var watch in watches)
        {
            if (!watchesDictionary.TryGetValue(watch.Id, out var quantityToReduceBy))
            {
               throw new ArgumentException($"The watch {watch.Name} {watch.Reference} does not exist.");
            }

            if (watch.Stock.Quantity < quantityToReduceBy || watch.Stock.Quantity == 0)
            {
                throw new ArgumentException($"The watch {watch.Name} {watch.Reference} does not have enough stock. The stock quantity is {watch.Stock.Quantity}.");
            }
            
            watch.Stock.Quantity -= quantityToReduceBy;
            
            totalPrice += quantityToReduceBy * watch.Price;
        }
        
        //TODO unit of work pattern
        // Using the same context to save all changes 
        // await _watchRepository.SaveAllAsync();

        return totalPrice;
    }

    public void AddPriceToOrderItems(List<Watch> watches, Order order)
    {
        foreach (var item in order.Items)
        {
            item.Price = watches.Find(x => x.Id == item.ProductId)!.Price;
        }
    }
    
}