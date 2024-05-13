using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class WatchService
{
    private readonly DataContext _dataContext;

    public WatchService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
    {
        return await _dataContext.Watches.ToListAsync();
    }
    
    public async Task<ActionResult<Watch>> GetWatchById(int id)
    {
        return await _dataContext.Watches.FindAsync(id);
    }
}