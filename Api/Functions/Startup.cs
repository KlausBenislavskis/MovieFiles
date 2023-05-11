using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using MovieFiles.Api.Functions;
using MovieFiles.Infrastructure;
using System;

[assembly: FunctionsStartup(typeof(Startup))]

namespace MovieFiles.Api.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string dbServer = Environment.GetEnvironmentVariable("MOVIE_DB_SERVER");
            string dbName = Environment.GetEnvironmentVariable("MOVIE_DB_NAME");
            string dbUser = Environment.GetEnvironmentVariable("MOVIE_DB_USER");
            string dbPass = Environment.GetEnvironmentVariable("MOVIE_DB_PASS");

            builder.Services.AddInfrastructure(dbServer,dbName,dbUser,dbPass); 
        }
    }
}
