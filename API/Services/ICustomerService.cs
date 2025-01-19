using API.Entities.OrderEntities;

namespace API.Services;

public interface ICustomerService
{
    Order UpdateCustomerDetailToExistingUser(int appUserId, Order order);
}