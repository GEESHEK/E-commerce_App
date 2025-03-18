using API.Data.Repositories;
using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using API.Extensions;
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
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public OrderController(IOrderRepository orderRepository, IWatchRepository watchRepository,
        IOrderService orderService, ICustomerService customerService, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _watchRepository = watchRepository;
        _orderService = orderService;
        _customerService = customerService;
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _orderRepository.GetOrderById(id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [Authorize]
    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<OrderHistoryDto>>> GetUserOrderHistory()
    {
        try
        {
            var userId = User.GetUserId();
            
            var orderHistory = await _orderRepository.GetUserOrderHistoryByUserId(userId);

            if (orderHistory == null)
            {
                return NotFound("User has no order history");
            }

            return Ok(orderHistory);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet("success/{orderId:int}")]
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

        var watches = await _watchRepository.GetWatchesByIds(watchIds);

        if (watches.Count == 0)
        {
            return BadRequest("No watches were found");
        }

        //call the service to check watch availability and reduced the watch by item purchased
        var mappedOrder = _mapper.Map<Order>(orderDto);

        var totalPrice = 0m;
        //TODO Start transaction here maybe
        //Call PlaceOrder with a try and catch, the exception will be thrown up so we can return a bad request
        
        try
        {
            totalPrice = await _orderService.ReduceWatchQuantityAndReturnTotalPrice(watches, mappedOrder);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        //Add total to the order
        mappedOrder.Total = totalPrice;

        _orderService.AddPriceToOrderItems(watches, mappedOrder);

        try
        {
            var userId = User.GetUserId();

            if (userId > 0)
            {
                // Authenticated user: Update customer details
                mappedOrder.CustomerDetail.AppUserId = userId;

                var updatedOrder = _customerService.UpdateAndAddCustomerDetailToExistingUser(userId, mappedOrder);
                
                _orderRepository.CreateOrder(updatedOrder);
                
                if (await _orderRepository.SaveAllAsync())
                {
                    var order = await _orderRepository.GetSuccessOrderById(updatedOrder.Id);
                    
                    if (order == null)
                    {
                        return NotFound("Order was not found");
                    }
                
                    return Ok(order);
                }
                
                return BadRequest("Failed to create order");
            }
            
            // Guest user: Create order without updating customer details
            _orderRepository.CreateOrder(mappedOrder);
            
            if (await _orderRepository.SaveAllAsync())
            {
                var order = await _orderRepository.GetSuccessOrderById(mappedOrder.Id);
                
                if (order == null)
                {
                    return NotFound("Order was not found");
                }
                
                return Ok(order);
            }

            return BadRequest("Failed to create order");
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while creating order");
        }
    }

    // private async Task<ActionResult<SuccessOrderDto>> CreateAndSaveOrder(Order order)
    // {
    //     _orderRepository.CreateOrder(order);
    //     
    //     if (await _orderRepository.SaveAllAsync())
    //     {
    //         return await _orderRepository.GetSuccessOrderById(order.Id);
    //     }
    //
    //     return null;
    // }
}