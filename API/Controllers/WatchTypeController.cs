using API.Data.Repositories;
using API.Entities.Watch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WatchTypeController : BaseApiController
{
    private readonly IWatchTypeRepository _watchTypeRepository;

    public WatchTypeController(IWatchTypeRepository watchTypeRepository)
    {
        _watchTypeRepository = watchTypeRepository;
    }
        
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WatchType>>> GetWatchTypes()
    {
        var watchTypes = await _watchTypeRepository.GetWatchTypes();
        
        return Ok(watchTypes); 
    }
}