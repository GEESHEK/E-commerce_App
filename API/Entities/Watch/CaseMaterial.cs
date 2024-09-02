using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities.Watch;

[ExcludeFromCodeCoverage]
public class CaseMaterial
{
    public int Id { get; set; }
    public string Material { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}