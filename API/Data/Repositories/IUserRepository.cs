using API.DTOs.OrderDTOs;
using API.Entities.OrderEntities;
using API.Entities.UserEntities;

namespace API.Data.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<AppUser>> GetUsers();
    Task<AppUser> GetUserById(int id);
    Task<CustomerDetailDto> GetCustomerDetailByUserId(int userId);
    void AddCustomerDetail(CustomerDetail customerDetail, int userId);
    void SetCustomerDetailIsMainToFalse();
    Task<bool> SaveAllAsync();
}