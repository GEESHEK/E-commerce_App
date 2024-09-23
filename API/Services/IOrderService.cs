using API.Entities.OrderEntities;
using API.Entities.WatchEntities;

namespace API.Services;

public interface IOrderService
{
    Task<decimal> ReduceWatchQuantityAndReturnTotalPrice(List<Watch> watches, Order order);
}