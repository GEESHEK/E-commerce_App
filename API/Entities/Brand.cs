using System.Text.Json.Serialization;

namespace API.Entities;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}