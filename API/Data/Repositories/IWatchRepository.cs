using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface IWatchRepository
{
    void AddWatch(Watch watch);
    void DeleteWatch(Watch watch);
    Task<IEnumerable<Watch>> GetWatches();
    Task<Watch> GetWatchById(int id);
    Task<bool> SaveAllAsync();
    Task<bool> WatchExists(string reference);
    bool IsModified(Watch watch);
    Task<List<WatchCardDto>> GetHomepageWatchCards();
    Task<List<WatchCardDto>> GetWatchCards();
}