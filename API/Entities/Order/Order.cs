using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities.Order;

[ExcludeFromCodeCoverage]
public class Order
{
    public int Id { get; set; }
    public bool HasUser { get; set; }
    // public User User { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public string Reference { get; set; }
    [JsonIgnore]
    public int CustomerDetailId { get; set; }
    public CustomerDetail CustomerDetail { get; set; }
    [JsonIgnore]
    public int StatusTypeId { get; set; }
    public StatusType StatusType { get; set; }
    //TODO find a way to calculate this, static method
    public decimal Total { get; set; }
    public List<Item> Items { get; set; } = new();
}