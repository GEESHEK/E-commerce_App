using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchesController : ControllerBase
{
    private readonly WatchService _watchService;

    public WatchesController(WatchService watchService)
    {
        _watchService = watchService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
    {
        return await _watchService.GetWatches();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Watch>> GetWatch(int id)
    {
        return await _watchService.GetWatchById(id);
    }
}