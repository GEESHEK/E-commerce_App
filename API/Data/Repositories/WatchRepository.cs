using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Data.Repositories;

public class WatchRepository : IWatchRepository
{
    private readonly DataContext _dataContext;

    public WatchRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IEnumerable<Watch>> GetWatchesAsync()
    {
        return await _dataContext.Watches
            .Include(w => w.Brand)
            .Include(w => w.Calibre)
            .Include(w => w.CaseMaterial)
            .Include(w => w.Crystal)
            .Include(w => w.Dial)
            .Include(w => w.MovementType)
            .Include(w => w.Photos)
            .Include(w => w.PowerReserve)
            .Include(w => w.Stock)
            .Include(w => w.StrapBraceletMaterial)
            .Include(w => w.WatchCaseMeasurements)
            .Include(w => w.WatchType)
            .Include(w => w.WaterResistance)
            .ToListAsync();
    }

    public async Task<Watch> GetWatchByIdAsync(int id)
    {
        return await _dataContext.Watches
            .Include(w => w.Brand)
            .Include(w => w.Calibre)
            .Include(w => w.CaseMaterial)
            .Include(w => w.Crystal)
            .Include(w => w.Dial)
            .Include(w => w.MovementType)
            .Include(w => w.PowerReserve)
            .Include(w => w.Stock)
            .Include(w => w.StrapBraceletMaterial)
            .Include(w => w.WatchCaseMeasurements)
            .Include(w => w.WatchType)
            .Include(w => w.WaterResistance)
            .SingleOrDefaultAsync(w => w.Id == id);
    }
}