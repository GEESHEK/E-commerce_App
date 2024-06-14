using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class WatchRepository : IWatchRepository
{
    private readonly DataContext _context;

    public WatchRepository(DataContext context)
    {
        _context = context;
    }
    
    public void AddWatch(Watch watch)
    {
        _context.Watches.Add(watch);
    }
    
    public async Task<IEnumerable<Watch>> GetWatches()
    {
        return await _context.Watches
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

    public async Task<Watch> GetWatchById(int id)
    {
        return await _context.Watches
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
            .SingleOrDefaultAsync(w => w.Id == id);
    }
    
    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> WatchExists(string reference)
    {
        return await _context.Watches.AnyAsync(x => x.Reference.ToLower() == reference.ToLower());
    }
}