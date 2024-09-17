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
                CustomerDetailId = 1,
                StatusTypeId = 1,
                Total = 2545.00m,
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
                CustomerDetailId = 2,
                StatusTypeId = 2,
                Total = 2545.00m,
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
                CustomerDetailId = 3,
                StatusTypeId = 3,
                Total = 750.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 1,
                        ItemTypeId = 1,
                        Quantity = 3,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 4,
                StatusTypeId = 4,
                Total = 300.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 2,
                        ItemTypeId = 1,
                        Quantity = 2,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 5,
                StatusTypeId = 5,
                Total = 499.99m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 7,
                        ItemTypeId = 1,
                        Quantity = 1,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 6,
                StatusTypeId = 6,
                Total = 500.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 11,
                        ItemTypeId = 1,
                        Quantity = 1,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 7,
                StatusTypeId = 7,
                Total = 1000.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 8,
                        ItemTypeId = 1,
                        Quantity = 1,
                    }
                }
            }
        };
    }
}