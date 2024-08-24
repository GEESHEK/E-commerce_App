using API.Entities;

namespace API.Data.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<WatchType>> GetCategories();
    Task<bool> CategoryExists(int id);
}