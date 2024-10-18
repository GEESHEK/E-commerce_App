using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using API.Entities.UserEntities;

namespace API.Entities.OrderEntities;

[ExcludeFromCodeCoverage]
public class CustomerDetail
{
    public int Id { get; set; }
    public int? AppUserId { get; set; }
    [JsonIgnore]
    public AppUser? AppUser { get; set; }
    public bool? IsMain { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    [JsonIgnore]
    public List<Order> Orders { get; set; }
}