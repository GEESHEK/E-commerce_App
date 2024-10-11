using AutoMapper;

namespace API.Helpers;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        this.AddWatchMappings();
        this.AddOrderMappings();
    }
}