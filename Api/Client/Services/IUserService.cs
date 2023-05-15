namespace MovieFiles.Api.Client.Services
{
    public interface IUserService
    {
        Task ResolveUser(Guid userId, string username);
    }
}
