using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class WatchTypeRepository : IWatchTypeRepository
{
    private readonly DataContext _context;

    public WatchTypeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WatchType>> GetWatchTypes()
    {
        return await _context.WatchTypes.AsNoTracking().ToListAsync();
    }

    public async Task<bool> WatchTypeExists(int id)
    {
        return await _context.WatchTypes.AnyAsync(x => x.Id == id);
    }
}