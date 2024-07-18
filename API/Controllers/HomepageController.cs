using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class HomepageController : BaseApiController
{
    private readonly IWatchRepository _watchRepository;

    public HomepageController(IWatchRepository watchRepository)
    {
        _watchRepository = watchRepository;
    }
    
    [HttpGet("watch-cards")]
    public async Task<ActionResult<List<WatchCardDto>>> GetHomepageWatches()
    {
        var homepageWatches = await _watchRepository.GetHomepageWatchCards();

        return Ok(homepageWatches);
    }

}