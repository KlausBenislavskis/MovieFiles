using LinqToDB;
using MovieFiles.Core.Interfaces;
using MovieFiles.Infrastructure.Mappers;
using MovieFiles.Infrastructure.Scaffold;

namespace MovieFiles.Infrastructure.Repositories
{
    internal class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string serverName, string databaseName, string userName, string password) : base(serverName, databaseName, userName, password)
        {
        }

        public async  Task ResolveUser(Guid userId, string username)
        {
            using var db = GetQuantityDbUserConnection();
            var user = await db.Users.FirstOrDefaultAsync(user => user.UserName == username && user.UserId == userId);
            if(user != default) { return; }

            await db.InsertOrReplaceAsync(new User()
            {
                UserName = username,
                UserId = userId,
            });
        }

        public async Task<IList<Core.Models.User>> GetUsersByName(string username)
        {
            var db = GetQuantityDbUserConnection();
            var users = await db.Users.Where(user => user.UserName.Contains(username)).ToListAsync();
            return users.Select(DbToDom.Map).ToList();
        }

        public async Task<IList<Core.Models.User>> GetFollowing(Guid userId)
        {
            var db = GetQuantityDbUserConnection();
            var following = await db.Followers.Where(user => user.UserId == userId).ToListAsync();
            var users = await db.Users.Where(user => following.Select(follow => follow.FollowsUserId).Contains(user.UserId)).ToListAsync();
            return users.Select(DbToDom.Map).ToList();
        }

        public async Task Follow(Guid userId, Guid followingUserId)
        {
            var db = GetQuantityDbUserConnection();
            var following = await db.Followers.FirstOrDefaultAsync(user => user.UserId == userId && user.FollowsUserId == followingUserId);
            if(following != default) { return; }

            await db.InsertAsync(DomToDb.Map(userId, followingUserId));
        }

        public Task Unfollow(Guid userId, Guid followingUserId)
        {
            var db = GetQuantityDbUserConnection();
            return db.Followers.Where(user => user.UserId == userId && user.FollowsUserId == followingUserId).DeleteAsync();
        }
        
    }
}
