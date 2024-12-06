using API.DTOs.WatchDTOs;
using API.Entities.WatchEntities;
using AutoMapper;

namespace API.Helpers;

public static class WatchMappings
{
    public static void AddWatchMappings(this Profile profile)
    {
        profile.CreateMap<CreateWatchDto, Watch>()
            .ForPath(dest => dest.Stock.Quantity,
                opt => opt.MapFrom(src => src.Stock));
        profile.CreateMap<WatchUpdateDto, Watch>()
            .ForPath(dest => dest.Stock.Quantity,
                opt => opt.MapFrom(src => src.Stock));
        //When you need to include relational data
        profile.CreateMap<Watch, WatchCardDto>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(dest => dest.Stock,
                opt => opt.MapFrom(src => src.Stock.Quantity));
        profile.CreateMap<Watch, WatchDetailDto>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Calibre,
                opt => opt.MapFrom(src => src.Calibre.Name))
            .ForMember(dest => dest.CaseMaterial,
                opt => opt.MapFrom(src => src.CaseMaterial.Material))
            .ForMember(dest => dest.Crystal,
                opt => opt.MapFrom(src => src.Crystal.Material))
            .ForMember(dest => dest.Dial,
                opt => opt.MapFrom(src => src.Dial.Colour))
            .ForMember(dest => dest.MovementType,
                opt => opt.MapFrom(src => src.MovementType.Type))
            .ForMember(dest => dest.PowerReserve,
                opt => opt.MapFrom(src => src.PowerReserve.Duration))
            .ForMember(dest => dest.Stock,
                opt => opt.MapFrom(src => src.Stock.Quantity))
            .ForMember(dest => dest.StrapBraceletMaterial,
                opt => opt.MapFrom(src => src.StrapBraceletMaterial.Material))
            .ForMember(dest => dest.Diameter,
                opt => opt.MapFrom(src => src.WatchCaseMeasurements.Diameter))
            .ForMember(dest => dest.Thickness,
                opt => opt.MapFrom(src => src.WatchCaseMeasurements.Thickness))
            .ForMember(dest => dest.Length,
                opt => opt.MapFrom(src => src.WatchCaseMeasurements.Length))
            .ForMember(dest => dest.LugWidth,
                opt => opt.MapFrom(src => src.WatchCaseMeasurements.LugWidth))
            .ForMember(dest => dest.WatchType,
                opt => opt.MapFrom(src => src.WatchType.Type))
            .ForMember(dest => dest.WaterResistance,
                opt => opt.MapFrom(src => src.WaterResistance.Resistance));
        profile.CreateMap<Watch, CartWatchDto>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Dial,
                opt => opt.MapFrom(src => src.Dial.Colour))
            .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(dest => dest.Stock,
                opt => opt.MapFrom(src => src.Stock.Quantity));
    }
}