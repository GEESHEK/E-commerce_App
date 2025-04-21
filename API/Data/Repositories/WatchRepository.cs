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
        
        if (userParams.Brands != null && userParams.Brands.Length != 0)
        {
            query = query.Where(w => userParams.Brands.Contains(w.Brand.Name));
        }

        if (userParams.Calibres != null && userParams.Calibres.Length != 0)
        {
            query = query.Where(w => userParams.Calibres.Contains(w.Calibre.Name));
        }

        if (userParams.Dials != null && userParams.Dials.Length != 0)
        {
            query = query.Where(w => userParams.Dials.Contains(w.Dial.Colour));
        }
        
        if (userParams.Diameters != null && userParams.Diameters.Length != 0)
        {
            query = query.Where(w => userParams.Diameters.Contains(w.WatchCaseMeasurements.Diameter));
        }

        if (userParams.MovementTypes != null && userParams.MovementTypes.Length != 0)
        {
            query = query.Where(w => userParams.MovementTypes.Contains(w.MovementType.Type));
        }
        
        if (userParams.WatchTypes != null && userParams.WatchTypes.Length != 0)
        {
            query = query.Where(w => userParams.WatchTypes.Contains(w.WatchType.Type));
        }

        if (userParams.Price != null && userParams.Price.Length != 0)
        {
            query = userParams.Price[0] == "Low to High" ? query.OrderBy(x => x.Price).ThenByDescending(x => x.DateAdded) 
                : query.OrderByDescending(x => x.Price).ThenByDescending(x => x.DateAdded);
            
            return await PagedList<WatchCardDto>.CreateAsync(query.ProjectTo<WatchCardDto>(_mapper.ConfigurationProvider), userParams.PageNumber, userParams.PageSize);
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
            Brands = await _context.Brands.Select(b => b.Name).OrderBy(b => b).AsNoTracking().ToListAsync(),
            Calibres = await _context.Calibres.Select(c => c.Name).OrderBy(c => c).AsNoTracking().ToListAsync(),
            Dials = await _context.Dials.Select(d => d.Colour).OrderBy(d => d).AsNoTracking().ToListAsync(),
            MovementTypes = await _context.MovementTypes.Select(m => m.Type).OrderBy(m => m).AsNoTracking().ToListAsync(),
            WatchTypes = await _context.WatchTypes.Select(w => w.Type).OrderBy(w => w).AsNoTracking().ToListAsync(),
            Diameters = await _context.WatchCaseMeasurements.Select(w => w.Diameter).Distinct().OrderBy(w => w).ToListAsync()
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