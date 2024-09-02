using System.Diagnostics.CodeAnalysis;
using API.Entities.Watch;

namespace API.Data.SeedData.Watch;

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