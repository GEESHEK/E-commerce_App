using System.Diagnostics.CodeAnalysis;
using API.Entities.Watch;

namespace API.Data.SeedData.Watch;

[ExcludeFromCodeCoverage]
public static class DialSeedData
{
    public static List<Dial> GetDialSeedData()
    {
        return new List<Dial>()
        {
            new()
            {
                Colour = "Black"
            },
            new()
            {
                Colour = "White"
            },
            new()
            {
                Colour = "Blue"
            },
            new()
            {
                Colour = "Red"
            },
            new()
            {
                Colour = "Yellow"
            },
            new()
            {
                Colour = "Green"
            },
            new()
            {
                Colour = "Pink"
            },
            new()
            {
                Colour = "Light blue"
            },
            new()
            {
                Colour = "Grey"
            },
            new()
            {
                Colour = "Silver"
            },
            new()
            {
                Colour = "Gold"
            }
        };
    }
}