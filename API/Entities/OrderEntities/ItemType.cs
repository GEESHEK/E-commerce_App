using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities.OrderEntities;

[ExcludeFromCodeCoverage]
public class ItemType
{
    public int Id { get; set; }
    public string Type { get; set; }
    [JsonIgnore]
    public List<Item> Items { get; set; } = new();
}