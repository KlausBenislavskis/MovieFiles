using Microsoft.AspNetCore.Components.Authorization;
using MovieFiles.Api.Client.Services;

namespace MovieFiles.Ui.Http.Helpers
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

            if (user.Identity.IsAuthenticated)
            {
                // Your custom logic here
                // You can use the _userService to communicate with your database
            }
        }
    }
}