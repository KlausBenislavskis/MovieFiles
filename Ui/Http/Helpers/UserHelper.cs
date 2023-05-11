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
    }
}
