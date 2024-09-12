using System.Diagnostics.CodeAnalysis;
using API.Entities.OrderEntities;

namespace API.Data.SeedData.Order;

[ExcludeFromCodeCoverage]
public static class OrderSeedData
{
    public static List<Entities.OrderEntities.Order> GetOrderSeedData()
    {
        return new List<Entities.OrderEntities.Order>()
        {
            new()
            {
                HasUser = false,
                Reference = "12345",
                CustomerDetailId = 1,
                StatusTypeId = 1,
                Total = 1234.56m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 12,
                        ItemTypeId = 1,
                        Quantity = 1,
                    },
                    new()
                    {
                        ProductId = 10,
                        ItemTypeId = 1,
                        Quantity = 2,
                    }
                }
            },
            new()
            {
                HasUser = false,
                Reference = "123456",
                CustomerDetailId = 2,
                StatusTypeId = 3,
                Total = 1234.56m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 12,
                        ItemTypeId = 1,
                        Quantity = 1,
                    },
                    new()
                    {
                        ProductId = 10,
                        ItemTypeId = 1,
                        Quantity = 2,
                    }
                }
            }
        };
    }
}