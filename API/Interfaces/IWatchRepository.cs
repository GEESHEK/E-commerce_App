using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface IWatchRepository
{
    Task<IEnumerable<Watch>> GetWatchesAsync();
    Task<Watch> GetWatchByIdAsync(int id);
}