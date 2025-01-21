using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipleExtensions 
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        var username = user.FindFirst(ClaimTypes.Name)?.Value;
        
        return string.IsNullOrEmpty(username) ? null : username;
    }
    
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return -1;
        }

        if (!int.TryParse(userIdClaim, out var userId))
        {
            return -1;
        }

        return userId;
    }
}