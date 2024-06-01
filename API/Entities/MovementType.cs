using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class MovementType
{
    public int Id { get; set; }
    public string Type { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}