﻿using LinqToDB;
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
    }
}