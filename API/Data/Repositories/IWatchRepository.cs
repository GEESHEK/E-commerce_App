using API.DTOs.WatchDTOs;
using API.Entities.WatchEntities;
using API.Helpers.Pagination;

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
    Task<bool> WatchExists(int id);
    bool IsModified(Watch watch);
    Task<IEnumerable<WatchCardDto>> GetHomepageWatchCards();
    Task<PagedList<WatchCardDto>> GetWatchCards(UserParams userParams);
    Task<IEnumerable<CartWatchDto>> GetCartWatchesByIds(List<int> ids);
    Task<List<Watch>> GetWatchesByIds(List<int> ids);
    Task<IEnumerable<WatchCardDto>> GetWatchCardsByBrandId(int brandId);
    Task<IEnumerable<WatchCardDto>> GetWatchCardsByWatchTypeId(int watchTypeId);
    Task<WatchFilterDto> GetWatchFilters();
}