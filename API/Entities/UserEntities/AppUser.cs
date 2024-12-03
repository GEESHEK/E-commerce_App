using API.Entities.OrderEntities;

namespace API.Entities.UserEntities;

public class AppUser
{
    public int Id { get; set; }
    public string KnownAs { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string Gender { get; set; }
    public List<CustomerDetail> CustomerDetails  { get; set; } = new();
}