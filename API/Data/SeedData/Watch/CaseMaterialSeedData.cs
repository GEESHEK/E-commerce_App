using System.Diagnostics.CodeAnalysis;
using API.Entities.WatchEntities;

namespace API.Data.SeedData.Watch;

[ExcludeFromCodeCoverage]
public static class CaseMaterialSeedData
{
    public static List<CaseMaterial> GetCaseMaterialSeedData()
    {
        return new List<CaseMaterial>()
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
            }
        };
    }
}