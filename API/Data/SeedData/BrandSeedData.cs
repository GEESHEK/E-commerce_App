using System.Diagnostics.CodeAnalysis;
using API.Entities;

namespace API.Data.SeedData;

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
            new Brand()
            {
                Name = "Citizen"
            },
        };
    }
}