using API.Data.Repositories;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WatchController : BaseApiController
{
    private readonly IWatchRepository _watchRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IWatchTypeRepository _watchTypeRepository;
    private readonly IMapper _mapper;

    public WatchController(IWatchRepository watchRepository, IBrandRepository brandRepository,
        IWatchTypeRepository watchTypeRepository, IMapper mapper)
    {
        _watchRepository = watchRepository;
        _brandRepository = brandRepository;
        _watchTypeRepository = watchTypeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
    {
        var watches = await _watchRepository.GetWatches();

        return Ok(watches);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Watch>> GetWatch(int id)
    {
        var watch = await _watchRepository.GetWatchById(id);

        if (watch == null)
        {
            return NotFound();
        }

        return Ok(watch);
    }

    [HttpPost]
    public async Task<ActionResult<Watch>> CreateWatch(CreateWatchDto createWatchDto)
    {
        if (createWatchDto == null) return BadRequest();

        if (await _watchRepository.WatchExists(createWatchDto.Reference))
            return BadRequest("Watch reference already exists");

        var watch = _mapper.Map<Watch>(createWatchDto);

        _watchRepository.AddWatch(watch);

        if (await _watchRepository.SaveAllAsync())
            return CreatedAtAction(nameof(GetWatch), new { id = watch.Id }, watch);

        //Todo come back to catch other errors: look at notes if you return bool in save all then nothing can be caught
        return BadRequest("Failed to add watch");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateWatch(int id, WatchUpdateDto watchUpdateDto)
    {
        var watch = await _watchRepository.GetWatchById(id);

        if (watch == null) return NotFound();

        _mapper.Map(watchUpdateDto, watch);

        if (!_watchRepository.IsModified(watch)) return BadRequest("No changes made");

        if (await _watchRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update watch");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteWatch(int id)
    {
        var watch = await _watchRepository.GetWatchById(id);

        if (watch == null) return NotFound();

        _watchRepository.DeleteWatch(watch);

        if (await _watchRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Problem deleting watch");
    }

    [HttpGet("watch-cards")]
    public async Task<ActionResult<IEnumerable<WatchCardDto>>> GetWatchCards([FromQuery] string brand, [FromQuery] string watchType)
    {
        //TODO sending up both query parameters don't work for now, fix this in pagination
        
        Console.Write("watch card method ----------------" + brand, watchType);
        
        if (!string.IsNullOrEmpty(brand))
        {
            if (!await _brandRepository.BrandExists(brand)) return NotFound("Brand not found");

            return Ok(await _watchRepository.GetWatchCardsByBrandName(brand));
        }
        
        if (!string.IsNullOrEmpty(watchType))
        {
            if (!await _watchTypeRepository.WatchTypeExists(watchType)) return NotFound("Watch type not found");

            return Ok(await _watchRepository.GetWatchCardsByWatchTypeName(watchType));
        }
        
        return Ok(await _watchRepository.GetWatchCards());
    }

    [HttpGet("watch-detail/{id:int}")]
    public async Task<ActionResult<WatchDetailDto>> GetWatchDetailById(int id)
    {
        var watchDetail = await _watchRepository.GetWatchDetailById(id);

        if (watchDetail == null)
        {
            return NotFound();
        }

        return Ok(watchDetail);
    }

    [HttpGet("by-brand/{brandId:int}")]
    public async Task<ActionResult<WatchCardDto>> GetWatchCardsByBrandId(int brandId)
    {
        if (!await _brandRepository.BrandExists(brandId)) return NotFound("Brand not found");

        var watchCards = await _watchRepository.GetWatchCardsByBrandId(brandId);

        return Ok(watchCards);
    }

    [HttpGet("by-watchType/{watchTypesId:int}")]
    public async Task<ActionResult<WatchCardDto>> GetWatchCardsByWatchTypeId(int watchTypesId)
    {
        if (!await _watchTypeRepository.WatchTypeExists(watchTypesId)) return NotFound("Watch type not found");

        var watchCards = await _watchRepository.GetWatchCardsByWatchTypeId(watchTypesId);

        return Ok(watchCards);
    }

    //Todo add photo or do this in it's own controller
}