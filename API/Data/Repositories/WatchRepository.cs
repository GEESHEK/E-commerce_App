using API.DTOs.WatchDTOs;
using API.Entities.WatchEntities;
using API.Helpers.Pagination;
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

    public async Task<WatchDetailDto> GetWatchDetailById(int id)
    {
        return await _context.Watches
            .Where(w => w.Id == id)
            .ProjectTo<WatchDetailDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<bool>SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool IsModified(Watch watch)
    {
        return _context.Entry(watch).State == EntityState.Modified;
    }

    public async Task<IEnumerable<WatchCardDto>> GetHomepageWatchCards()
    {
        // The includes for Photo and Brand is handled in the AutomapperProfiles
        return await _context.Watches
            .OrderByDescending(x => x.DateAdded)
            .Take(8)
            .AsNoTracking()
            .ProjectTo<WatchCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<PagedList<WatchCardDto>> GetWatchCards(UserParams userParams)
    {
        var query = _context.Watches.AsQueryable();

        if (userParams.Brand != null)
        {
            query = query.Where(w => w.Brand.Name == userParams.Brand);
        }
        
        if (userParams.WatchType != null)
        {
            query = query.Where(w => w.WatchType.Type == userParams.WatchType);
        }

        query = query.OrderByDescending(x => x.DateAdded)
            .AsNoTracking();
        
        return await PagedList<WatchCardDto>.CreateAsync(query.ProjectTo<WatchCardDto>(_mapper.ConfigurationProvider), userParams.PageNumber, userParams.PageSize);
    }

    public async Task<IEnumerable<CartWatchDto>> GetCartWatchesByIds(List<int> ids)
    {
        return await _context.Watches
            .Where(x => ids.Contains(x.Id))
            .AsNoTracking()
            .ProjectTo<CartWatchDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<List<Watch>> GetWatchesByIds(List<int> ids)
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
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<WatchCardDto>> GetWatchCardsByBrandId(int brandId)
    {
        return await _context.Watches
            .Where(x => x.BrandId == brandId)
            .AsNoTracking()
            .ProjectTo<WatchCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<WatchCardDto>> GetWatchCardsByWatchTypeId(int watchTypeId)
    {
        return await _context.Watches
            .Where(x => x.WatchTypeId == watchTypeId)
            .AsNoTracking()
            .ProjectTo<WatchCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<WatchFilterDto> GetWatchFilters()
    {
        return new WatchFilterDto
        {
            Brands = await _context.Brands.Select(b => b.Name).ToListAsync(),
            Calibres = await _context.Calibres.Select(c => c.Name).ToListAsync(),
            Dials = await _context.Dials.Select(d => d.Colour).ToListAsync(),
            MovementTypes = await _context.MovementTypes.Select(m => m.Type).ToListAsync(),
            WatchTypes = await _context.WatchTypes.Select(w => w.Type).ToListAsync(),
            Diameters = await _context.WatchCaseMeasurements.Select(w => w.Diameter).Distinct().ToListAsync()
        };
    }

    public async Task<bool> WatchExists(string reference)
    {
        return await _context.Watches.AnyAsync(x => x.Reference.ToLower() == reference.ToLower());
    }
    
    public async Task<bool> WatchExists(int id)
    {
       return await _context.Watches.AnyAsync(x => x.Id == id);
    }
}