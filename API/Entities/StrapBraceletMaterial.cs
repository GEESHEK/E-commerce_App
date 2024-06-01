using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class StrapBraceletMaterial
{
    public int Id { get; set; }
    public string Material { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}