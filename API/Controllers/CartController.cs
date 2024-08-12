using API.Data.Repositories;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CartController : BaseApiController
{
    private readonly IWatchRepository _watchRepository;

    public CartController(IWatchRepository watchRepository)
    {
        _watchRepository = watchRepository;
    }
    
    [HttpGet("watches")]
    public async Task<ActionResult<IEnumerable<CartWatchDto>>> GetWatches([FromQuery] List<int> ids)
    {
        var watchCards = await _watchRepository.GetCartWatches(ids);

        return Ok(watchCards);
    }
}