using API.Entities;
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
}