using API.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<AppUser>> GetUsers()
    {
        return await _context.AppUsers.AsNoTracking().ToListAsync();
    }

    public async Task<AppUser> GetUserById(int id)
    {
        return await _context.AppUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}