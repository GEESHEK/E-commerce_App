using System.Diagnostics.CodeAnalysis;
using API.Entities;

namespace API.Data.SeedData;

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