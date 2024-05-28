using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class WatchRepository : IWatchRepository
{
    private readonly DataContext _dataContext;

    public WatchRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatchesAsync()
    {
        return await _dataContext.Watches
                //circular reference > fix this
            .Include(w => w.Brand)
            .ToListAsync();
    }

    public async Task<ActionResult<Watch>> GetWatchByIdAsync(int id)
    {
        return await _dataContext.Watches.FindAsync(id);
    }
}