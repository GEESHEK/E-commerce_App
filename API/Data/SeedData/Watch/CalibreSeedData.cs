using System.Diagnostics.CodeAnalysis;
using API.Entities.Watch;

namespace API.Data.SeedData.Watch;

[ExcludeFromCodeCoverage]
public static class CalibreSeedData
{
    public static List<Calibre> GetCalibreSeedData()
    {
        return new List<Calibre>()
        {
            new()
            {
                Name = "Calibre1"
            },
            new()
            {
                Name = "Calibre2"
            },
            new()
            {
                Name = "Calibre3"
            }
        };
    }
}