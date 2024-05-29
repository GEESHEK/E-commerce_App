using System.Text.Json.Serialization;

namespace API.Entities;

public class StrapBraceletMaterial
{
    public int Id { get; set; }
    public string Material { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}