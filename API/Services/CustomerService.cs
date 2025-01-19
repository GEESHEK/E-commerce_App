using API.Data.Repositories;
using API.Entities.OrderEntities;

namespace API.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Order UpdateCustomerDetailToExistingUser(int appUserId, Order order)
    {
        var customerDetail = _customerRepository.GetCustomerDetailByAppUserId(appUserId).Result;

        if (customerDetail == null)
        {
            order.CustomerDetail.AppUserId = appUserId;
            order.CustomerDetail.IsMain = false;
            return order;
        }
        
        if (CheckIfDetailsMatch(customerDetail, order.CustomerDetail))
        {
            order.CustomerDetail = null;
            order.CustomerDetailId = customerDetail.Id;
            return order;
        }

        order.CustomerDetail.AppUserId = appUserId;
        order.CustomerDetail.IsMain = false;
        return order;
    }

    private static bool CheckIfDetailsMatch(CustomerDetail customerDetail, CustomerDetail orderCustomerDetail)
    {
        if (customerDetail.FirstName != orderCustomerDetail.FirstName)
        {
            return false;
        }

        if (customerDetail.Surname != orderCustomerDetail.Surname)
        {
            return false;
        }

        if (customerDetail.Email != orderCustomerDetail.Email)
        {
            return false;
        }

        if (customerDetail.PhoneNumber != orderCustomerDetail.PhoneNumber)
        {
            return false;
        }

        if (customerDetail.Address != orderCustomerDetail.Address)
        {
            return false;
        }

        if (customerDetail.ZipCode != orderCustomerDetail.ZipCode)
        {
            return false;
        }

        if (customerDetail.City != orderCustomerDetail.City)
        {
            return false;
        }

        if (customerDetail.Country != orderCustomerDetail.Country)
        {
            return false;
        }

        return true;
    }
}