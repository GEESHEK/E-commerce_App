using API.Entities.OrderEntities;

namespace API.Services;

public interface ICustomerService
{
    Order UpdateAndAddCustomerDetailToExistingUser(int appUserId, Order order);
}