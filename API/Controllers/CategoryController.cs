using API.Data.Repositories;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoryController : BaseApiController
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
        
    [HttpGet]
    public async Task<ActionResult<List<WatchType>>> GetWatchCategories()
    {
        var categories = await _categoryRepository.GetCategories();
        
        return Ok(categories); 
    }
}