using API.Data.Repositories;
using API.DTOs;
using API.Entities.OrderEntities;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrderController : BaseApiController
{
    private readonly IOrderRepository _orderRepository;
    private readonly IWatchRepository _watchRepository;
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderRepository orderRepository, IWatchRepository watchRepository,
        IOrderService orderService, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _watchRepository = watchRepository;
        _orderService = orderService;
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

        List<int> watchIds = new List<int>();

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
                case > 4:
                    return BadRequest("Unknown item type");
            }

            watchIds.Add(item.ProductId);
        }

        watchIds = watchIds.Distinct().ToList();
        var watches = await _watchRepository.GetWatchesByIds(watchIds);
        
        //call the service to check watch availability and reduced the watch by item purchased

        var mappedOrder = _mapper.Map<Order>(orderDto);

        _orderRepository.CreateOrder(mappedOrder);

        //Add total to the order

        //create the cost

        //TODO send mapped Order to OrderService, 

        if (await _orderRepository.SaveAllAsync())
        {
            // var 
        }

        return Ok("Success");
        // return await _orderRepository.CreateOrder(orderDto);
    }
}