using API.Entities.OrderEntities;
using API.Entities.WatchEntities;

namespace API.Services;

public interface IOrderService
{
    Task<List<Watch>> CheckAndReduceWatchQuantity(List<Watch> watches, List<Item> items);
    Task<decimal> CalculateTotalPrice(IEnumerable<Watch> watches);
}