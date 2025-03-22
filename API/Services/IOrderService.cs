using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using API.Entities.WatchEntities;

namespace API.Services;

public interface IOrderService
{
    Task<SuccessOrderDto> PlaceOrder(Order order, List<Watch> watches, int userId);
    decimal ReduceWatchQuantityAndReturnTotalPrice(List<Watch> watches, Order order);
    void AddPriceToOrderItems(List<Watch> watches, Order order);
}