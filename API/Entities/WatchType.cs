using System.Text.Json.Serialization;

namespace API.Entities;

public class WatchType
{
    public int Id { get; set; }
    public string Type { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}