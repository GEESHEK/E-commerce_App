using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class CustomerDetail
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerZipCode { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerCountry { get; set; }
    [JsonIgnore]
    public int OrderId { get; set; }
    [JsonIgnore]
    public Order Order { get; set; }
}