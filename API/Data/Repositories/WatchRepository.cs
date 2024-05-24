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
            .Include(b => b.Brand)
            .Include(c => c.Case.Dial)
            // .ThenInclude(d => d.Dial)
            .Include(c => c.Case.WatchCaseMeasurements)
            .ToListAsync();
    }

    public async Task<ActionResult<Watch>> GetWatchByIdAsync(int id)
    {
        return await _dataContext.Watches.FindAsync(id);
    }
}