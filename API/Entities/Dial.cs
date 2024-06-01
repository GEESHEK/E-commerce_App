using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class Dial
{
    public int Id { get; set; }
    public string Colour { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}