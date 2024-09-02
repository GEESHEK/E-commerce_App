using System.Diagnostics.CodeAnalysis;

namespace API.Entities.Order;

[ExcludeFromCodeCoverage]
public class Order
{
    public int Id { get; set; }
    public bool HasUser { get; set; }
    // public User User { get; set; }
    public DateTime DateTime { get; set; }
    public string Reference { get; set; }
    public CustomerDetail CustomerDetail { get; set; }
    public string Status { get; set; }
    public decimal Total { get; set; }
    public List<Item> Items { get; set; } = new();
}