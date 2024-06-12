using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class Stock
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public int WatchId { get; set; }
    [JsonIgnore]
    public Watch Watch { get; set; }
}