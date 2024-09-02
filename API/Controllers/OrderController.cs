using API.Data.Repositories;
using API.Entities.Order;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrderController : BaseApiController
{
    private readonly IOrderRepository _orderRepository;
    private readonly IWatchRepository _watchRepository;

    public OrderController(IOrderRepository orderRepository, IWatchRepository watchRepository)
    {
        _orderRepository = orderRepository;
        _watchRepository = watchRepository;
    }

    [HttpPost]
    public async Task<bool> AddOrder(Order order)
    {
        return await _orderRepository.AddOrder(order);
    }
    
    
}