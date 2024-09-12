using API.Data.Repositories;
using API.Entities.OrderEntities;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _orderRepository.GetOrders();
        
        return Ok(orders);
    }
    
    [HttpGet("status/{statusId:int}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByStatus(int statusId)
    {
        var orders = await _orderRepository.GetOrdersByStatus(statusId);
        
        return Ok(orders);
    }


    [HttpPost]
    public async Task<bool> AddOrder(Order order)
    {
        return await _orderRepository.AddOrder(order);
    }
}