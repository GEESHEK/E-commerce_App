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
}