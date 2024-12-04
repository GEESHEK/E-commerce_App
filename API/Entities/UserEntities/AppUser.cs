using API.Entities.OrderEntities;

namespace API.Entities.UserEntities;

public class AppUser
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public string Gender { get; set; }
    public List<CustomerDetail> CustomerDetails  { get; set; } = new();
}