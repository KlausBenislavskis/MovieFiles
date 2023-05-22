using MovieFiles.Core.Models;

namespace MovieFiles.Api.Client.Services
{
    public interface IUserService
    {
        Task ResolveUser(Guid userId, string username);
        Task<List<User>> SearchUsersByName(string userName);
    }
}
