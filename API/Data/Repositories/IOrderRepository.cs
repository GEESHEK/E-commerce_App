using API.Entities.OrderEntities;

namespace API.Data.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrder();
    Task<Order> GetOrderById();
    Task<bool> AddOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(Order order);
}