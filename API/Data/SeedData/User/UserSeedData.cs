using System.Diagnostics.CodeAnalysis;
using API.Entities.UserEntities;

namespace API.Data.SeedData.User;

[ExcludeFromCodeCoverage]
public static class UserSeedData
{
    public static List<AppUser> GetUserSeedData()
    {
        var users = new Dictionary<string, int>()
        {
            { "Gee", 0 },
            { "Hana", 1 },
            { "Hina", 1 },
        };
      
        return CreateUsers(users);
    }

    public static List<AppRole> GetRoleSeedData()
    {
        var roles = new List<AppRole>()
        {
            new() { Name = "User" },
            new() { Name = "Admin" },
        };
        
        return roles;
    }

    private static List<AppUser> CreateUsers(Dictionary<string,int> users)
    {
        var appUsers = new List<AppUser>();

        foreach (var user in users)
        {
            var appUser = new AppUser
            {
                UserName = user.Key,
                Gender = user.Value == 0 ? Gender.Male : Gender.Female
            };

            appUsers.Add(appUser);
        }

        return appUsers;
    }
}