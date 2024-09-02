using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities.Watch;

[ExcludeFromCodeCoverage]
public class PowerReserve
{
    public int Id { get; set; }
    public int Duration { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}