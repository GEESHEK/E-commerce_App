using API.Data.Repositories;
using API.DTOs;
using API.Entities.OrderEntities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrderController : BaseApiController
{
    private readonly IOrderRepository _orderRepository;
    private readonly IWatchRepository _watchRepository;
    private readonly IMapper _mapper;

    public OrderController(IOrderRepository orderRepository, IWatchRepository watchRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _watchRepository = watchRepository;
        _mapper = mapper;
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
    public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
    {
        if (orderDto == null) return BadRequest();
        
        //check if itemTypes exists

        foreach (var item in orderDto.Items)
        {
            switch (item.ItemTypeId)
            {
                //if the !await does work then you need to check case 1 first, then check if watchExist then check if its false
                case 1 when !await _watchRepository.WatchExists(item.ProductId):
                    return BadRequest("Watch does not exist");
                case 2 or 3: //when await > different product repo
                    return BadRequest("These item types are not being sold yet");
                default:
                    return BadRequest("Unknown item type");
            }
        }
        
        var order = _mapper.Map<Order>(orderDto);
        
        _orderRepository.CreateOrder(order);

        return Ok("Success");
        // return await _orderRepository.CreateOrder(orderDto);
    }
}