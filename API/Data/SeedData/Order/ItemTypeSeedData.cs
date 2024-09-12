using System.Diagnostics.CodeAnalysis;
using API.Entities.OrderEntities;

namespace API.Data.SeedData.Order;

[ExcludeFromCodeCoverage]
public static class ItemTypeSeedData
{
    public static List<ItemType> GetItemTypeSeedData()
    {
        return new List<ItemType>()
        {
            new()
            {
                Type = "Watch"
            },
            new()
            {
                Type = "Strap"
            },
            new()
            {
                Type = "Case"
            }
        };
    }
}