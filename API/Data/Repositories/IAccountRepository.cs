using API.DTOs.UserDTOs;
using API.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Repositories;

public interface IAccountRepository
{
    Task<IdentityResult> AddUser(AppUser user, string password);
    Task<bool> UserExists(string username);
    Task<AppUser> UserExists(LoginDto loginDto);
    Task<bool> CheckPassword(AppUser user, string password);
}