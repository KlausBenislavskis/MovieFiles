using MovieFiles.Infrastructure.Scaffold;
using Npgsql;

namespace MovieFiles.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string _serverName;
        private readonly string _databaseName;
        private readonly string _userName;
        private readonly string _password;

        internal MovieFilesDb GetQuantityDbUserConnection()
        {
            return MovieFilesDb.WithServerConnectionString(GetServerConnectionString());
        }

        protected BaseRepository(string serverName, string databaseName, string userName, string password)
        {
            _serverName = serverName;
            _databaseName = databaseName;
            _userName = userName;
            _password = password;
        }


        public string GetServerConnectionString()
        {
            NpgsqlConnectionStringBuilder builder = new()
            {
                Host = _serverName,
                Database = _databaseName,
                SslMode = SslMode.Prefer,
                Username = _userName,
                Password = _password,
                TrustServerCertificate = true,
                Pooling = true,
                Port = 5432
            };


            return builder.ConnectionString;
        }



    }
}
