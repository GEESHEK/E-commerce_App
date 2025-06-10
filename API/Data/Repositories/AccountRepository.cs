using API.DTOs.UserDTOs;
using API.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly UserManager<AppUser> _userManager;

    public AccountRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<IdentityResult> AddUser(AppUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<bool> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.NormalizedUserName == username.ToUpper());
    }
    
    public async Task<AppUser> UserExists(LoginDto loginDto)
    {
        return await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == loginDto.Username.ToUpper());
    }
    
    public async Task<bool> CheckPassword(AppUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
}