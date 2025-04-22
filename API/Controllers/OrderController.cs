using API.Data.Repositories;
using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using API.Exceptions;
using API.Extensions;
using API.Helpers.Pagination;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

    // [HttpGet("{id:int}")]
    // public async Task<ActionResult<Order>> GetOrder(int id)
    // {
    //     var order = await _orderRepository.GetOrderById(id);
    //
    //     if (order == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return Ok(order);
    // }

    [Authorize]
    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<OrderHistoryDto>>> GetUserOrderHistory([FromQuery] UserParams userParams)
    {
        try
        {
            var userId = User.GetUserId();

            var orderHistory = await _orderRepository.GetUserOrderHistoryByUserId(userId, userParams);

            if (orderHistory == null)
            {
                return NotFound("User has no order history");
            }
            
            Response.AddPaginationHeader(orderHistory);

            return Ok(orderHistory);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet("{orderId:int}")]
    public async Task<ActionResult<SuccessOrderDto>> GetSuccessOrder(int orderId)
    {
        try
        {
            var userId = User.GetUserId();

            var order = await _orderRepository.GetSuccessOrderByOrderIdAndUserId(orderId, userId);

            if (order == null)
            {
                return NotFound("Order no. does not belong to user");
            }

            return Ok(order);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<SuccessOrderDto>> CreateOrder(OrderDto orderDto)
    {
        if (orderDto == null) return BadRequest();

        var userId = User.GetUserId();
        var watchIds = new List<int>();

        //check if itemTypes exists
        foreach (var item in orderDto.Items)
        {
            if (item.Quantity <= 0)
            {
                return BadRequest("Items quantity must be greater than 0");
            }

            switch (item.ItemTypeId)
            {
                case 1:
                    if (!await _watchRepository.WatchExists(item.ProductId)) return BadRequest("Watch does not exist");
                    watchIds.Add(item.ProductId);
                    break;
                case 2 or 3: //when await > different product repo
                    return BadRequest("These item types are not being sold yet");
                default:
                    return BadRequest("Unknown item type");
            }
        }

        var watches = await _watchRepository.GetWatchesByIds(watchIds);

        if (watches.Count == 0)
        {
            return BadRequest("No watches were found");
        }

        var mappedOrder = _mapper.Map<Order>(orderDto);

        //Start the transaction of reducing stock count and creating order
        try
        {
            return Ok(await _orderService.PlaceOrder(mappedOrder, watches, userId));
        }
        catch (FailedToCreateOrderException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}