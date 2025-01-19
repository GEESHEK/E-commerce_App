using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
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
      
        return CreateUsers(users, "Pa$$w0rd");
    }

    private static List<AppUser> CreateUsers(Dictionary<string,int> users, string password)
    {
        var hashedUsers = new List<AppUser>();

        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();

            var appUser = new AppUser
            {
                UserName = user.Key.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                Gender = user.Value == 0 ? Gender.Male : Gender.Female
            };

            hashedUsers.Add(appUser);
        }

        return hashedUsers;
    }
}