namespace MovieFiles.Infrastructure.Scaffold
{

    public partial class MovieFilesDb
    {
        public MovieFilesDb(string providerName, string connectionString) : base(providerName, connectionString)
        {
            InitDataContext();
        }

        public static MovieFilesDb WithServerConnectionString(string connectionString)
        {
            return new MovieFilesDb("PostgreSQL", connectionString);
        }
    }
}
