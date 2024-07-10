using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class WatchRepository : IWatchRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public WatchRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public void AddWatch(Watch watch)
    {
        _context.Watches.Add(watch);
    }

    public void DeleteWatch(Watch watch)
    {
        _context.Watches.Remove(watch);
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
            .AsNoTracking()
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
            //Tracking changes because put and delete will need it to check for changes
            .SingleOrDefaultAsync(w => w.Id == id);
    }
    
    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool IsModified(Watch watch)
    {
        return _context.Entry(watch).State == EntityState.Modified;
    }

    public async Task<List<HomepageWatchDto>> GetHomepageWatches()
    {
        // The includes for Photo and Brand is handled in the AutomapperProfiles
        return await _context.Watches
            .OrderByDescending(x => x.DateAdded)
            .Take(8)
            .AsNoTracking()
            .ProjectTo<HomepageWatchDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<bool> WatchExists(string reference)
    {
        return await _context.Watches.AnyAsync(x => x.Reference.ToLower() == reference.ToLower());
    }
}