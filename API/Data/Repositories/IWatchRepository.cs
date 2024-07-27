using API.DTOs;
using API.Entities;

namespace API.Data.Repositories;

public interface IWatchRepository
{
    void AddWatch(Watch watch);
    void DeleteWatch(Watch watch);
    Task<IEnumerable<Watch>> GetWatches();
    Task<Watch> GetWatchById(int id);
    Task<WatchDetailDto> GetWatchDetailById(int id);
    Task<bool> SaveAllAsync();
    Task<bool> WatchExists(string reference);
    bool IsModified(Watch watch);
    Task<List<WatchCardDto>> GetHomepageWatchCards();
    Task<List<WatchCardDto>> GetWatchCards();
}