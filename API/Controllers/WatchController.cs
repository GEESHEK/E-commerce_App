using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchController : ControllerBase
{
    private readonly IWatchRepository _watchRepository;

    public WatchController(IWatchRepository watchRepository)
    {
        _watchRepository = watchRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
    {
        return await _watchRepository.GetWatchesAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Watch>> GetWatch(int id)
    {
        return await _watchRepository.GetWatchByIdAsync(id);
    }
}