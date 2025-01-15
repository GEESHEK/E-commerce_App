using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using AutoMapper;

namespace API.Helpers;

public static class UserMappings
{
    public static void AddUserMappings(this Profile profile)
    {
        profile.CreateMap<CustomerDetail, CustomerDetailDto>();
        profile.CreateMap<CustomerDetailDto, CustomerDetail>();
    }
}