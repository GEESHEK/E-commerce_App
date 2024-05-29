using System.Text.Json.Serialization;

namespace API.Entities;

public class Dial
{
    public int Id { get; set; }
    public string Colour { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}