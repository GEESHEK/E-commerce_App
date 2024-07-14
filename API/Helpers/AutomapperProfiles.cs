using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        CreateMap<CreateWatchDto, Watch>()
            .ForPath(d => d.Stock.Quantity,
                o => o.MapFrom(s => s.Stock));
        CreateMap<WatchUpdateDto, Watch>()
            .ForPath(d => d.Stock.Quantity,
                o => o.MapFrom(s => s.Stock));
        //When you need to include relational data
        CreateMap<Watch, WatchCardDto>()
            .ForMember(d => d.Brand,
                o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.PhotoUrl,
                o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));
    }
}