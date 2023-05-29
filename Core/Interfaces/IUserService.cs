using MovieFiles.Core.Models;

namespace MovieFiles.Api.Client.Services
{
    public interface IUserService
    {
        Task ResolveUser(Guid userId, string username);
        Task<List<User>> SearchUsersByName(string userName);
        Task<List<User>> GetFollowing(Guid userId);
        Task<List<User>> GetFollowers(Guid userId);
        Task Follow(Guid userId, Guid followingUserId);
        Task Unfollow(Guid userId, Guid followingUserId);
    }
}
