using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Identity.Web;
using MovieFiles.Api.Client.Services;
using MovieFiles.Api.Client.Services.Interfaces;
using MovieFiles.Ui.Http.Helpers;

namespace MovieFiles.Ui.Http.Data
{
    public interface IUserResolver
    {
        Task ResolveUser();
    }

    public class UserResolver : IUserResolver
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IUserService _userService;

        public UserResolver(AuthenticationStateProvider authenticationStateProvider, IUserService userService)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _userService = userService;
        }

        public async Task ResolveUser()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user?.Identity?.IsAuthenticated?? false)
            {
                 await _userService.ResolveUser(user.GetUserId(), user?.Identity?.Name);
            }
        }
    }
}