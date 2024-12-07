using API.DTOs.UserDTOs;
using API.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly DataContext _context;

    public AccountRepository(DataContext context)
    {
        _context = context;
    }
    
    
    public void AddUser(AppUser user)
    {
        _context.AppUsers.Add(user);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UserExists(string username)
    {
        return await _context.AppUsers.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }

    public async Task<AppUser> UserExists(LoginDto loginDto)
    {
        return await _context.AppUsers.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
    }
}