using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using API.Entities.UserEntities;
using AutoMapper;

namespace API.Helpers.Automapper;

public static class UserMappings
{
    public static void AddUserMappings(this Profile profile)
    {
        profile.CreateMap<CustomerDetail, CustomerDetailDto>();
        profile.CreateMap<CustomerDetailDto, CustomerDetail>();
        profile.CreateMap<AppUser, OrderHistoryDto>();
    }
}