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
    Task<IEnumerable<WatchCardDto>> GetHomepageWatchCards();
    Task<IEnumerable<WatchCardDto>> GetWatchCards();
    Task<IEnumerable<CartWatchDto>> GetCartWatches(List<int> ids);
    Task<IEnumerable<WatchCardDto>> GetWatchCardsByBrandId(int brandId);
    Task<IEnumerable<WatchCardDto>> GetWatchCardsByCategoryId(int categoryId);
}