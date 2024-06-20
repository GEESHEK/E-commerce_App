using System.Diagnostics.CodeAnalysis;
using API.Entities;

namespace API.Data.SeedData;

[ExcludeFromCodeCoverage]
public static class WatchTypeSeedData
{
    public static List<WatchType> GetWatchTypeSeedData()
    {
        return new List<WatchType>()
        {
            new()
            {
                Type = "Dress"
            },
            new()
            {
                Type = "GMT"
            },
            new()
            {
                Type = "Chronograph"
            },
            new()
            {
                Type = "Digital"
            },
            new()
            {
                Type = "Solar"
            },
            new()
            {
                Type = "Smart"
            },
            new()
            {
                Type = "Diver"
            },
        };
    }
}