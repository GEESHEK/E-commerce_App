using API.Entities.OrderEntities;

namespace API.Data.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrders();
    Task<Order> GetOrderById();
    Task<IEnumerable<Order>> GetOrdersByStatus(int statusId);
    void CreateOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(Order order);
}