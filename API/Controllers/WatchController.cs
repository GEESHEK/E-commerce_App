using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WatchController : BaseApiController
{
    private readonly IWatchRepository _watchRepository;

    public WatchController(IWatchRepository watchRepository)
    {
        _watchRepository = watchRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
    {
        var watches = await _watchRepository.GetWatchesAsync();

        return Ok(watches);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Watch>> GetWatch(int id)
    {
        var watch = await _watchRepository.GetWatchByIdAsync(id);
        
        if (watch == null)
        {
            return NotFound();
        }
        
        return Ok(watch);
    }
}