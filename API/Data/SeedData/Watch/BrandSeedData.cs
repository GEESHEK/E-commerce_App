using System.Diagnostics.CodeAnalysis;
using API.Entities.Watch;

namespace API.Data.SeedData.Watch;

[ExcludeFromCodeCoverage]
public static class BrandSeedData
{
    public static List<Brand> GetBrandSeedData()
    {
        return new List<Brand>()
        {
            new()
            {
                Name = "Seiko"
            },
            new()
            {
                Name = "Casio"
            },
            new()
            {
                Name = "Grand Seiko"
            },
            new()
            {
                Name = "Orient"
            },
            new()
            {
                Name = "Citizen"
            },
        };
    }
}