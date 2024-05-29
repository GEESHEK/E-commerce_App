using System.Text.Json.Serialization;

namespace API.Entities;

public class Calibre
{ 
    public int Id { get; set; }
    public String Name { get; set; }
    [JsonIgnore]
    public List<Watch> Watches { get; set; } = new();
}