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
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerService _customerService;

    public OrderService(DataContext context, IOrderRepository orderRepository, ICustomerService customerService)
    {
        _context = context;
        _orderRepository = orderRepository;
        _customerService = customerService;
    }

    public async Task<SuccessOrderDto> PlaceOrder(Order order, List<Watch> watches, int userId)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var totalPrice = ReduceWatchQuantityAndReturnTotalPrice(watches, order);
            order.Total = totalPrice;

            AddPriceToOrderItems(watches, order);

            if (userId > 0)
            {
                // Authenticated user: Update customer details
                order.CustomerDetail.AppUserId = userId;

                _customerService.UpdateAndAddCustomerDetailToExistingUser(userId, order);
                
                _orderRepository.CreateOrder(order);
            }
            
            // Guest user: Create order without updating customer details
            _orderRepository.CreateOrder(order);
            
            // Save all changes together (stock reduction and order creation)
            if (await _context.SaveChangesAsync() > 0)
            {
                // Finalize transaction
                await transaction.CommitAsync();

                var successOrder = await _orderRepository.GetSuccessOrderById(order.Id);

                return successOrder;
            }

            throw new FailedToCreateOrderException("Failed to create order");
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public decimal ReduceWatchQuantityAndReturnTotalPrice(List<Watch> watches, Order order)
    {
        var totalPrice = 0m;

        if (watches == null || watches.Count == 0)
        {
            throw new ArgumentException("Watches cannot be null or empty", nameof(watches));
        }

        if (order.Items == null || order.Items.Count == 0)
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
                throw new ArgumentException(
                    $"The watch {watch.Name} {watch.Reference} does not have enough stock. The stock quantity is {watch.Stock.Quantity}.");
            }

            watch.Stock.Quantity -= quantityToReduceBy;

            totalPrice += quantityToReduceBy * watch.Price;
        }

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