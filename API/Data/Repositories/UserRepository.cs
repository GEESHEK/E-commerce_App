using API.Entities.UserEntities;

namespace API.Data.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<IEnumerable<AppUser>> GetUsers()
    {
        return null;
    }
}