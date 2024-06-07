using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WatchController : BaseApiController
{
    private readonly IWatchRepository _watchRepository;
    private readonly IMapper _mapper;

    public WatchController(IWatchRepository watchRepository, IMapper mapper)
    {
        _watchRepository = watchRepository;
        _mapper = mapper;
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

    // [HttpPut]
    // public async Task<ActionResult> UpdateWatch(Watch watch)
    // {
    //     var oldWatch = _watchRepository.GetWatchByIdAsync(watch.Id);
    //     
    // }
}