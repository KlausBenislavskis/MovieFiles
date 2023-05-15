namespace MovieFiles.Infrastructure.Repositories
{
    internal class UserRepository : BaseRepository
    {
        public UserRepository(string serverName, string databaseName, string userName, string password) : base(serverName, databaseName, userName, password)
        {
        }
    }
}
