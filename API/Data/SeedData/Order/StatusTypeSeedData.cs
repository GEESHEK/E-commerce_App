using System.Diagnostics.CodeAnalysis;
using API.Entities.OrderEntities;

namespace API.Data.SeedData.Order;

[ExcludeFromCodeCoverage]
public static class StatusTypeSeedData
{
    public static List<StatusType> GetStatusTypeSeedData()
    {
        return new List<StatusType>()
        {
            new()
            {
                Status = "Order Confirmed"
            },
            new()
            {
                Status = "Processing"
            },
            new()
            {
                Status = "Shipped"
            },
            new()
            {
                Status = "Delivered"
            },
            new()
            {
                Status = "Cancelled"
            },
            new()
            {
                Status = "Refunded"
            }
        };
    }
}