using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface IWatchRepository
{
    Task<ActionResult<IEnumerable<Watch>>> GetWatchesAsync();
    Task<ActionResult<Watch>> GetWatchByIdAsync(int id);
}