using System.Diagnostics.CodeAnalysis;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class Order
{
    public int Id { get; set; }
    public bool IsUser { get; set; }
    // public User User { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }
    public CustomerDetail CustomerDetail { get; set; }
    public string OrderStatus { get; set; }
    public decimal OrderTotal { get; set; }
    public List<Item> Items { get; set; } = new();
}