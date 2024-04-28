using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ProductService
{
    private readonly DataContext _dataContext;

    public ProductService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _dataContext.Products.ToListAsync();
    }
    
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        return await _dataContext.Products.FindAsync(id);
    }
}