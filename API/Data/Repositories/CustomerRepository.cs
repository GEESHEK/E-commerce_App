using API.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<CustomerDetail> GetCustomerDetailByAppUserId(int appUserId)
    {
        return await _context.CustomerDetails
            .FirstOrDefaultAsync(x => x.AppUserId == appUserId && x.IsMain == true);
    }
}