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
                o => o.MapFrom(s => s.Stock));
        CreateMap<WatchUpdateDto, Watch>()
            .ForPath(w => w.Stock.Quantity,
                o => o.MapFrom(s => s.Stock));
        CreateMap<Watch, HomepageWatchDto>()
            .ForPath(w => w.PhotoUrl,
                o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url))
        .ForPath(w => w.Brand,
            o => o.MapFrom(s => s.Brand.Name));
    }
}