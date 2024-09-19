using API.Entities.WatchEntities;

namespace API.Services;

public interface IOrderService
{
    Task<decimal> CalculateTotalPrice(IEnumerable<Watch> watches);
}