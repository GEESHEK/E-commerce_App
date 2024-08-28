using API.Entities;

namespace API.Data.Repositories;

public interface IWatchTypeRepository
{
    Task<IEnumerable<WatchType>> GetWatchTypes();
    Task<bool> WatchTypeExists(int id);
    Task<bool> WatchTypeExists(string watchType);
}