using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MovieFiles.Ui.Http.Helpers
{
    public static class UserHelper
    {
        public static async Task<Guid> GetUserId(this AuthenticationStateProvider user)
        {
            var authState = await user.GetAuthenticationStateAsync();
            return authState.User.GetUserId();
        }

        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
            return Guid.Parse(userId);
        }
        public static string GetUserName(this AuthenticationState state)
        {
            string username = "Unknown";
            if (state?.User?.Identity?.Name != null && state?.User?.Identity?.Name != "unknown")
            {
                username = state?.User?.Identity?.Name;
            }
            else
            {
                username = state?.User?.FindFirst(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;
            }
            return username;
        }
    }
}
