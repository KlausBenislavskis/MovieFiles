namespace MovieFiles.Api.Client.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }
    }
}
