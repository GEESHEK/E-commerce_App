using API.Entities.UserEntities;

namespace API.Services;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}