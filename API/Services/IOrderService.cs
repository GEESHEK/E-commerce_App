using API.Entities.OrderEntities;
using API.Entities.WatchEntities;

namespace API.Services;

public interface IOrderService
{
    Task<List<Watch>> CheckAndReduceWatchQuantity(List<Watch> watches, Order order);
    Task<decimal> CalculateTotalPrice(IEnumerable<Watch> watches);
}