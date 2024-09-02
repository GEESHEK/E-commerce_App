using System.Diagnostics.CodeAnalysis;
using API.Entities.Watch;

namespace API.Data.SeedData.Watch;

[ExcludeFromCodeCoverage]
public static class MovementTypeSeedData
{
    public static List<MovementType> GetMovementTypeSeedData()
    {
        return new List<MovementType>()
        {
            new()
            {
                Type = "Automatic"
            },
            new()
            {
                Type = "Manual Winding"
            },
            new()
            {
                Type = "Quartz"
            }
        };
    }
}