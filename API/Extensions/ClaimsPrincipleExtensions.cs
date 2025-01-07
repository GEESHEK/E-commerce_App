using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipleExtensions 
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        var username = user.FindFirst(ClaimTypes.Name)?.Value;

        if (string.IsNullOrEmpty(username))
        {
            throw new InvalidOperationException("Username claim not found.");
        }

        return username;
    }
    
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            throw new InvalidOperationException("User ID claim not found.");
        }

        if (!int.TryParse(userIdClaim, out var userId))
        {
            throw new FormatException("User ID claim is not a valid integer.");
        }

        return userId;
    }
}