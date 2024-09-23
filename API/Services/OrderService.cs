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

    public async Task<List<Watch>> CheckAndReduceWatchQuantity(List<Watch> watches, Order order)
    {
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
        }

        //TODO unit of work pattern
        await _watchRepository.SaveAllAsync();

        return watches;
    }

    public Task<decimal> CalculateTotalPrice(List<Item> items)
    {
        var totalPrice = 0m;

        var orderQ  = items[0].Quantity;
        
        //retrieve watch 
        
        // if (watches == null)
        // {
        //     return Task.FromResult(0m);
        // }
        //
        // foreach (var watch in watches)
        // {
        //     totalPrice += (watch.Price);
        // }
        
        return Task.FromResult(totalPrice);
    }

    public Task<IEnumerable<Watch>> GetWatchesById()
    {
        return null;
    }

    public Task<decimal> CalculateTotalPrice(IEnumerable<Watch> watches)
    {
        throw new NotImplementedException();
    }
}