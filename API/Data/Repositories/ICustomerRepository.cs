using API.Entities.OrderEntities;

namespace API.Data.Repositories;

public interface ICustomerRepository
{
    Task<CustomerDetail> GetCustomerDetailByAppUserId(int appUserId);
}