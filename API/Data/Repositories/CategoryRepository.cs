using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WatchType>> GetCategories()
    {
        return await _context.WatchTypes.AsNoTracking().ToListAsync();
    }
}