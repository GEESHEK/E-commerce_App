using System.Diagnostics.CodeAnalysis;
using API.Entities.Watch;

namespace API.Data.SeedData.Watch;

[ExcludeFromCodeCoverage]
public static class PowerReserveSeedData
{
    public static List<PowerReserve> GetPowerReserveSeedData()
    {
        return new List<PowerReserve>()
        {
            new()
            {
                Duration = 36
            },
            new()
            {
                Duration = 42
            },
            new()
            {
                Duration = 48
            }
        };
    }
}