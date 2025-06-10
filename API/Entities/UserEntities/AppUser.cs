using API.Entities.OrderEntities;
using Microsoft.AspNetCore.Identity;

namespace API.Entities.UserEntities;

public class AppUser : IdentityUser<int>
{
    public Gender Gender { get; set; }
    public List<CustomerDetail> CustomerDetails  { get; set; } = [];
    public ICollection<AppUserRole> UserRoles { get; set; } = [];
}