using System.Text.Json.Serialization;

namespace API.Entities;

public class WaterResistance
{
    public int Id { get; set; }
    public string Resistance { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}