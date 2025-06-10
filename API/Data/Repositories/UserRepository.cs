using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using API.Entities.UserEntities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<AppUser>> GetUsers()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }
    
    public async Task<AppUser> GetUserById(int id)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CustomerDetailDto> GetCustomerDetailByUserId(int userId)
    {
        return await _context.CustomerDetails
                .Where(x => x.AppUserId == userId && x.IsMain == true)
                // .AsNoTracking()
                .ProjectTo<CustomerDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
    }
    
    public void AddCustomerDetail(CustomerDetail customerDetail, int userId)
    {
        _context.CustomerDetails.Add(customerDetail);
        
    }

    public void SetCustomerDetailIsMainToFalse(int userId)
    {
        var customerDetail = _context.CustomerDetails
            .FirstOrDefaultAsync(x => x.IsMain == true && x.AppUserId == userId).Result;

        if (customerDetail != null)
        {
            customerDetail.IsMain = false;
        } 
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}