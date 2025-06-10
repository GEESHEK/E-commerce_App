using Microsoft.AspNetCore.Identity;

namespace API.Entities.UserEntities;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; } = [];
}