using API.Data.Repositories;
using API.Entities.OrderEntities;
using API.Entities.WatchEntities;

namespace API.Services;

public class OrderService : IOrderService
{
    private readonly IWatchRepository _watchRepository;

    public OrderService(IWatchRepository watchRepository)
    {
        _watchRepository = watchRepository;
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
        await _watchRepository.SaveAllAsync();

        return totalPrice;
    }
    
}