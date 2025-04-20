using API.Data.Repositories;
using API.DTOs.WatchDTOs;
using API.Entities.WatchEntities;
using API.Extensions;
using API.Helpers.Pagination;
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

        var mappedWatch = _mapper.Map<Watch>(createWatchDto);

        _watchRepository.AddWatch(mappedWatch);

        if (await _watchRepository.SaveAllAsync())
        {
            var watch = await _watchRepository.GetWatchById(mappedWatch.Id);
            return CreatedAtAction(nameof(GetWatch), new { id = mappedWatch.Id }, watch);
        }

        //Todo come back to catch other errors: look at notes if you return bool in save all then nothing can be caught
        return BadRequest("Failed to create watch");
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
    public async Task<ActionResult<IEnumerable<WatchCardDto>>> GetWatchCards([FromQuery] UserParams userParams)
    {
        if (userParams.Brand != null && !await _brandRepository.BrandExists(userParams.Brand)) return NotFound("Brand not found");

        if (userParams.WatchType != null && !await _watchTypeRepository.WatchTypeExists(userParams.WatchType)) return NotFound("Watch type not found");
        
        var watches = await _watchRepository.GetWatchCards(userParams);

        Response.AddPaginationHeader(watches);

        return Ok(watches);
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

    [HttpGet("filters")]
    public async Task<ActionResult<WatchFilterDto>> GetWatchFilters()
    {
        return Ok(await _watchRepository.GetWatchFilters());
    }

    //Todo add photo or do this in it's own controller
}