namespace MovieFiles.Api.Client.Services.Interfaces
{
    public interface IUserService
    {
        Task ResolveUser(Guid userId, string username);
    }
}
