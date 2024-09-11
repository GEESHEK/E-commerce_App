using System.Diagnostics.CodeAnalysis;
using API.Entities.Order;

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
                Status = "Completed"
            },
            new()
            {
                Status = "Canceled"
            },
            new()
            {
                Status = "Refunded"
            }
        };
    }
}