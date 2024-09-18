using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities.WatchEntities;

[ExcludeFromCodeCoverage]
public class WatchCaseMeasurements
{
    public int Id { get; set; }
    public double Diameter { get; set; }
    public double Thickness { get; set; }
    public double Length { get; set; }
    public double LugWidth { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}