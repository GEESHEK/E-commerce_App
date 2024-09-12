using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities.OrderEntities;

[ExcludeFromCodeCoverage]
public class Order
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public string Reference { get; set; }
    [JsonIgnore]
    public int CustomerDetailId { get; set; }
    public CustomerDetail CustomerDetail { get; set; }
    [JsonIgnore]
    public int StatusTypeId { get; set; }
    public StatusType StatusType { get; set; }
    public decimal Total { get; set; }
    public List<Item> Items { get; set; } = new();
}