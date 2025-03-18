using API.Data;
using API.Data.Repositories;
using API.Entities.OrderEntities;
using API.Entities.WatchEntities;

namespace API.Services;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly IWatchRepository _watchRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderService(DataContext context, IWatchRepository watchRepository, IOrderRepository orderRepository)
    {
        _context = context;
        _watchRepository = watchRepository;
        _orderRepository = orderRepository;
    }

    // public async Task<Order> PlaceOrder(Order order, List<Watch> watches)
    // {
    //     using (var transaction = await _context.Database.BeginTransactionAsync())
    //     {
    //         try
    //         {
    //             var totalPrice = await ReduceWatchQuantityAndReturnTotalPrice(watches, order);
    //             order.Total = totalPrice;
    //             
    //             // Save all changes together (stock reduction and order creation)
    //             await _context.SaveChangesAsync();
    //
    //             // Commit transaction
    //             await transaction.CommitAsync();
    //
    //             return mappedOrder;
    //         }
    //         catch (Exception)
    //         {
    //             await transaction.RollbackAsync();
    //             throw;
    //         }
    //     }
    // }

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
        await _watchRepository.SaveAllAsync();

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