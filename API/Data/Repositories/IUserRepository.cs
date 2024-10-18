using API.Entities.UserEntities;

namespace API.Data.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<AppUser>> GetUsers();
}