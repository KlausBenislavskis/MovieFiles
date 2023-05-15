namespace MovieFiles.Api.Client.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task ResolveUser(Guid userId, string username)
        {
            await _client.ResolveUserAsync(userId, username, _functionAppKey);
        }
    }
}
