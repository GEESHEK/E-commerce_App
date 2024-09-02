using System.Diagnostics.CodeAnalysis;

namespace API.Entities.Order;

[ExcludeFromCodeCoverage]
public class CustomerDetail
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    // [JsonIgnore]
    // public int OrderId { get; set; }
    // [JsonIgnore]
    // public Order Order { get; set; }
}