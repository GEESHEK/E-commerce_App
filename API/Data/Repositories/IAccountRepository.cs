using API.DTOs;
using API.Entities.UserEntities;

namespace API.Data.Repositories;

public interface IAccountRepository
{
    void AddUser(AppUser user);
    Task<bool> SaveAllAsync();
    Task<bool> UserExists(string username);
    Task<AppUser> UserExists(LoginDto loginDto);
}