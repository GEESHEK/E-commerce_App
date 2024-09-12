using API.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await _context.Orders
            .Include(o => o.CustomerDetail)
            .Include(o => o.StatusType)
            .Include(o => o.Items)
            .ThenInclude(i => i.ItemType)
            .AsNoTracking().ToListAsync();
    }

    public Task<Order> GetOrderById()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatus(int statusId)
    {
        return await _context.Orders.Where(w => w.StatusTypeId == statusId)
            .Include(o => o.CustomerDetail)
            .Include(o => o.StatusType)
            .Include(o => o.Items)
            .ThenInclude(i => i.ItemType)
            .AsNoTracking().ToListAsync();
    }

    public async Task<bool> AddOrder(Order order)
    {
        return true;
    }

    public Task UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrder(Order order)
    {
        throw new NotImplementedException();
    }
}