using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class WatchService
{
    private readonly IWatchRepository _watchRepository;

    public WatchService(IWatchRepository watchRepository)
    {
        _watchRepository = watchRepository;
    }
    
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
    {
        return await _watchRepository.GetWatchesAsync();
    }
    
    public async Task<ActionResult<Watch>> GetWatchById(int id)
    {
        return await _watchRepository.GetWatchByIdAsync(id);
    }
}