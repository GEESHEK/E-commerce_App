using System.Diagnostics.CodeAnalysis;
using API.Entities.OrderEntities;

namespace API.Data.SeedData.Order;

[ExcludeFromCodeCoverage]
public static class CustomerDetailSeedData
{
    public static List<CustomerDetail> GetCustomerDetailSeedData()
    {
        return new List<CustomerDetail>()
        {
            new()
            {
                FirstName = "John",
                Surname = "Doe",
                Email = "johndoe@fakemail.com",
                PhoneNumber = "01234567801",
                Address = "address 1",
                ZipCode = "12345",
                City = "City1",
                Country = "Country1"
            },
            new()
            {
                FirstName = "Jane",
                Surname = "Smith",
                Email = "janeSmith@fakemail.com",
                PhoneNumber = "09876543211",
                Address = "address 2",
                ZipCode = "12345",
                City = "City2",
                Country = "Country2"
            },
            new()
            {
                FirstName = "Michael",
                Surname = "Johnson",
                Email = "michael.johnson@fakemail.com",
                PhoneNumber = "01324567891",
                Address = "address 3",
                ZipCode = "23456",
                City = "City3",
                Country = "Country3"
            },
            new()
            {
                FirstName = "Emily",
                Surname = "Brown",
                Email = "emily.brown@fakemail.com",
                PhoneNumber = "09786543211",
                Address = "address 4",
                ZipCode = "34567",
                City = "City4",
                Country = "Country4"
            },
            new()
            {
                FirstName = "David",
                Surname = "Wilson",
                Email = "david.wilson@fakemail.com",
                PhoneNumber = "01432567891",
                Address = "address 5",
                ZipCode = "45678",
                City = "City5",
                Country = "Country5"
            },
            new()
            {
                FirstName = "Emma",
                Surname = "Davis",
                Email = "emma.davis@fakemail.com",
                PhoneNumber = "09186543211",
                Address = "address 6",
                ZipCode = "56789",
                City = "City6",
                Country = "Country6"
            },
            new()
            {
                FirstName = "Chris",
                Surname = "Martinez",
                Email = "chris.martinez@fakemail.com",
                PhoneNumber = "01543567891",
                Address = "address 7",
                ZipCode = "67890",
                City = "City7",
                Country = "Country7"
            },
            new()
            {
                FirstName = "Olivia",
                Surname = "Garcia",
                Email = "olivia.garcia@fakemail.com",
                PhoneNumber = "09086543211",
                Address = "address 8",
                ZipCode = "78901",
                City = "City8",
                Country = "Country8"
            },
            new()
            {
                FirstName = "James",
                Surname = "Rodriguez",
                Email = "james.rodriguez@fakemail.com",
                PhoneNumber = "01654567891",
                Address = "address 9",
                ZipCode = "89012",
                City = "City9",
                Country = "Country9"
            },
            new()
            {
                FirstName = "Sophia",
                Surname = "Hernandez",
                Email = "sophia.hernandez@fakemail.com",
                PhoneNumber = "08976543211",
                Address = "address 10",
                ZipCode = "90123",
                City = "City10",
                Country = "Country10"
            },
            new()
            {
                AppUserId = 1,
                IsMain = true,
                FirstName = "Gee",
                Surname = "Shek",
                Email = "gee.shek@fakemail.com",
                PhoneNumber = "11111111111",
                Address = "address 11",
                ZipCode = "90121",
                City = "City11",
                Country = "Country11"
            },
            new()
            {
                AppUserId = 2,
                IsMain = true,
                FirstName = "Hana",
                Surname = "Tanaka",
                Email = "hana.tanaka@fakemail.com",
                PhoneNumber = "11111111112",
                Address = "address 12",
                ZipCode = "90122",
                City = "City12",
                Country = "Country12"
            }
        };
    }
}