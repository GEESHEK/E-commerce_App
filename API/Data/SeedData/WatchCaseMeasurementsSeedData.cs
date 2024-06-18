using System.Diagnostics.CodeAnalysis;
using API.Entities;

namespace API.Data.SeedData;

[ExcludeFromCodeCoverage]
public static class WatchCaseMeasurementsSeedData
{
    public static List<WatchCaseMeasurements> GetWatchCaseMeasurementsSeedData()
    {
        return new List<WatchCaseMeasurements>()
        {
            new()
            {
                Diameter = 39, 
                Length = 46, 
                LugWidth = 20, 
                Thickness = 10
            },
            new()
            {
                Diameter = 40, 
                Length = 46, 
                LugWidth = 20, 
                Thickness = 10
            },
            new()
            {
                Diameter = 36, 
                Length = 44, 
                LugWidth = 18, 
                Thickness = 8
            },
        };
    }
}