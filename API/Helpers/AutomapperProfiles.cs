using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        CreateMap<CreateWatchDto, Watch>()
            .ForPath(w => w.Stock.Quantity,
                o => o.MapFrom(x => x.Stock));
    }
}