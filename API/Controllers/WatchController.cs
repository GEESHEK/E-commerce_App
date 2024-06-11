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
        var watches = await _watchRepository.GetWatches();

        return Ok(watches);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Watch>> GetWatch(int id)
    {
        var watch = await _watchRepository.GetWatchById(id);

        if (watch == null)
        {
            return NotFound();
        }

        return Ok(watch);
    }

    [HttpPost] //maybe change it to return bool
    public async Task<ActionResult<Watch>> CreateWatch(Watch watch)
    {
        // ModelState.IsValid: Checks if the model binding and validation passed.
        // BadRequest(ModelState): Returns a 400 Bad Request response if the model is invalid, including validation error messages.
        // if (!ModelState.IsValid)
        // {
        //     return BadRequest(ModelState);
        // }

        if (watch == null)
        {
            return BadRequest();
        }
        
        // if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
        
        //add validation to check if this watch already exists from its name or reference

        _watchRepository.AddWatch(watch);

        if (await _watchRepository.SaveAllAsync())
            return CreatedAtAction(nameof(GetWatch), new { id = watch.Id }, watch);

        return StatusCode(StatusCodes.Status500InternalServerError,
            "Error creating new watch record");
    }

    // [HttpPut]
    // public async Task<ActionResult> UpdateWatch(Watch watch)
    // {
    //     var oldWatch = _watchRepository.GetWatchByIdAsync(watch.Id);
    //     
    // }
}