using API.Entities.UserEntities;

namespace API.Services;

public interface ITokenService
{
    string CreateToken(AppUser user);
}