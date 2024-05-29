using System.Text.Json.Serialization;

namespace API.Entities;

public class PowerReserve
{
    public int Id { get; set; }
    public string Duration { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}