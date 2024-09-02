using System.Diagnostics.CodeAnalysis;

namespace API.Entities.Order;

[ExcludeFromCodeCoverage]
public class Item
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ItemType ItemType { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }
}