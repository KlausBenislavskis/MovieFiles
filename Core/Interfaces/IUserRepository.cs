

using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IUserRepository
    {
        Task ResolveUser(Guid userId, string username);
        Task<IList<User>> GetUsersByName(string username);
        Task<IList<User>> GetFollowing(Guid userId);
        Task Follow(Guid userId, Guid followingUserId);
        Task Unfollow(Guid userId, Guid followingUserId);

    }
}
