using System.Diagnostics.CodeAnalysis;
using API.Entities;

namespace API.Data.SeedData;

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
                Type = "'Manual Winding"
            },
            new()
            {
                Type = "Quartz"
            }
        };
    }
}