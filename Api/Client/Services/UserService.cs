namespace MovieFiles.Api.Client.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task ResolveUser(Guid userId, string username)
        {
            try
            {
                await _client.ResolveUserAsync(userId, username, _functionAppKey);
            }
            //Can happen if reloading page 10x fast
            catch (ApiException e)
            {
                Console.WriteLine(e);
            }
        }
        
        public async Task SearchUsersByName(string username)
        {
            try
            {
                await _client.SearchUsersByNameAsync(username, _functionAppKey);
            }
            //Can happen if reloading page 10x fast
            catch (ApiException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
