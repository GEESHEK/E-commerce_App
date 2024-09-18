using API.Entities.WatchEntities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly DataContext _context;

    public BrandRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brand>> GetBrands()
    {
        return await _context.Brands.AsNoTracking().ToListAsync();
    }

    public async Task<bool> BrandExists(int id)
    {
        return await _context.Brands.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> BrandExists(string brand)
    {
        return await _context.Brands.AnyAsync(x => x.Name == brand);
    }
}