using System.Diagnostics.CodeAnalysis;
using API.Entities;

namespace API.Data.SeedData;

[ExcludeFromCodeCoverage]
public static class StrapBraceletMaterialSeedData
{
    public static List<StrapBraceletMaterial> GetStrapBraceletMaterialSeedData()
    {
        return new List<StrapBraceletMaterial>()
        {
            new()
            {
                Material = "Stainless Steel"
            },
            new()
            {
                Material = "Ceramic"
            },
            new()
            {
                Material = "Titanium"
            },
            new()
            {
                Material = "Carbon Fibre"
            },
            new()
            {
                Material = "Gold"
            },
            new()
            {
                Material = "Rubber"
            },
            new()
            {
                Material = "Resin"
            },
            new()
            {
                Material = "Leather"
            }
        };
    }
}