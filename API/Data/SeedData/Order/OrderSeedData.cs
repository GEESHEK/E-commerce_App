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
                Total = 3620.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 12,
                        ItemTypeId = 1,
                        Price = 120.00m,
                        Quantity = 1,
                    },
                    new()
                    {
                        ProductId = 10,
                        ItemTypeId = 1,
                        Price = 1750.00m,
                        Quantity = 2,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 2,
                StatusTypeId = 2,
                Total = 3620.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 12,
                        ItemTypeId = 1,
                        Price = 120.00m,
                        Quantity = 1,
                    },
                    new()
                    {
                        ProductId = 10,
                        ItemTypeId = 1,
                        Price = 1750.00m,
                        Quantity = 2,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 3,
                StatusTypeId = 3,
                Total = 360.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 1,
                        ItemTypeId = 1,
                        Price = 120.00m,
                        Quantity = 3,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 4,
                StatusTypeId = 4,
                Total = 799.98m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 2,
                        ItemTypeId = 1,
                        Price = 399.99m,
                        Quantity = 2,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 5,
                StatusTypeId = 5,
                Total = 999.99m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 7,
                        ItemTypeId = 1,
                        Price = 999.99m,
                        Quantity = 1,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 6,
                StatusTypeId = 6,
                Total = 750.00m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 11,
                        ItemTypeId = 1,
                        Price = 750.00m,
                        Quantity = 1,
                    }
                }
            },
            new()
            {
                CustomerDetailId = 7,
                StatusTypeId = 7,
                Total = 1999.99m,
                Items = new List<Item>()
                {
                    new()
                    {
                        ProductId = 8,
                        ItemTypeId = 1,
                        Price = 1999.99m,
                        Quantity = 1,
                    }
                }
            }
        };
    }
}