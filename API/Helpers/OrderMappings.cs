using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using AutoMapper;

namespace API.Helpers;

public static class OrderMappings
{
    public static void AddOrderMappings(this Profile profile)
    {
        profile.CreateMap<OrderDto, Order>();
        profile.CreateMap<CustomerDetailDto, CustomerDetail>();
        profile.CreateMap<ItemDto, Item>();
        profile.CreateMap<Order, SuccessOrderDto>()
            .ForMember(dest => dest.StatusType,
                opt => opt.MapFrom(src => src.StatusType.Status));
        profile.CreateMap<CustomerDetail, CustomerDetailDto>();
        profile.CreateMap<Item, ItemDto>();
    }
}