using System.Diagnostics.CodeAnalysis;

namespace API.Entities.Order;

[ExcludeFromCodeCoverage]
public class ItemType
{
    public int Id { get; set; }
    public string Type { get; set; }
}