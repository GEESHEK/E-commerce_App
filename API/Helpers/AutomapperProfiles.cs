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
        CreateMap<WatchUpdateDto, Watch>()
            .ForPath(w => w.Stock.Quantity,
                o => o.MapFrom(x => x.Stock));
        CreateMap<Watch, HomepageWatches>();
        // .ForPath(w => w.Brand,
        //     o => o.MapFrom(x => x.Brand.Name));
    }
}