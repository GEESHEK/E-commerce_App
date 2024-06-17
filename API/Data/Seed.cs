using System.Diagnostics.CodeAnalysis;
using API.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

[ExcludeFromCodeCoverage]
public static class Seed
{
    public static async Task SeedWatches(DataContext context)
    {
        if (await context.Watches.AnyAsync()) return;
        
        await context.Brands.AddRangeAsync(BrandSeedData.GetBrandSeedData());
        await context.Calibres.AddRangeAsync(CalibreSeedData.GetCalibreSeedData());
        await context.CaseMaterials.AddRangeAsync(CaseMaterialSeedData.GetCaseMaterialSeedData());
        await context.Crystals.AddRangeAsync(CrystalSeedData.GetCrystalSeedData());
        await context.Dials.AddRangeAsync(DialSeedData.GetDialSeedData());
        //everything else comes before
        await context.Watches.AddRangeAsync(WatchSeedData.GetWatchSeedData());
        //stock seed comes last

        await context.SaveChangesAsync();
    }
}