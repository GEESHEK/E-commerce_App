using API.Data.Repositories;
using API.DTOs.WatchDTOs;
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
    public async Task<ActionResult<IEnumerable<CartWatchDto>>> GetWatches([FromQuery] string ids)
    {
        var idsArray = ids.Split(",");
        var watchIds = new List<int>();

        foreach (var idStr in idsArray)
        {
            if (int.TryParse(idStr, out var id))
            {
                watchIds.Add(id);
            }
            else
            {
                return BadRequest($"Invalid ID value: {idStr}");
            }
        }
        
        var cartWatches = await _watchRepository.GetCartWatchesByIds(watchIds);

        return Ok(cartWatches);
    }
}