using API.Data.Repositories;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BrandController : BaseApiController
{
    private readonly IBrandRepository _brandRepository;

    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Brand>>> GetWatchBrands()
    {
        var brands = await _brandRepository.GetBrands();

        return Ok(brands);
    }
}