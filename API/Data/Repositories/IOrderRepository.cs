using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;

namespace API.Data.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrders();
    Task<Order> GetOrderById(int id);
    Task<SuccessOrderDto> GetSuccessOrderById(int id);
    Task<List<SuccessOrderDto>> GetUserSuccessOrderByUserId(int userId);
    Task<IEnumerable<Order>> GetOrdersByStatus(int statusId);
    Task<bool> SaveAllAsync();
    void CreateOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(Order order);
}