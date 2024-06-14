using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface IWatchRepository
{
    void AddWatch(Watch watch);
    Task<IEnumerable<Watch>> GetWatches();
    Task<Watch> GetWatchById(int id);
    Task<bool> SaveAllAsync();
    Task<bool> WatchExists(string reference);
}