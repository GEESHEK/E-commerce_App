using AutoMapper;

namespace API.Helpers.Automapper;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        this.AddWatchMappings();
        this.AddOrderMappings();
        this.AddUserMappings();
    }
}