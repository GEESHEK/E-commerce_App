using System.Diagnostics.CodeAnalysis;
using API.Entities;

namespace API.Data.SeedData;

[ExcludeFromCodeCoverage]
public static class CrystalSeedData
{
    public static List<Crystal> GetCrystalSeedData()
    {
        return new List<Crystal>()
        {
            new()
            {
                Material = "Hardlex"
            },
            new()
            {
                Material = "Sapphire"
            },
            new()
            {
                Material = "Acrylic"
            },
            new()
            {
                Material = "Mineral"
            }
        };
    }
}