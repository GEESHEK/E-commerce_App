using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        CreateMap<CreateWatchDto, Watch>()
            .ForMember(w => w.Cost,
                o => o.MapFrom(x => x.Cost));
    }
}