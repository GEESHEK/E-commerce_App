using API.Entities.Order;

namespace API.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _dataContext;

    public OrderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task<IEnumerable<Order>> GetOrder()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrderById()
    {
        throw new NotImplementedException();
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