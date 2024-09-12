using System.Diagnostics.CodeAnalysis;

namespace API.Entities.OrderEntities;

[ExcludeFromCodeCoverage]
public class ItemType
{
    public int Id { get; set; }
    public string Type { get; set; }
    public List<Item> Items { get; set; } = new();
}