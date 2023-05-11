using Microsoft.Extensions.DependencyInjection;
using MovieFiles.Core.Interfaces;
using MovieFiles.Infrastructure.Repositories;

namespace MovieFiles.Infrastructure
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string serverName, string databaseName, string userName, string password)
        {

            services.AddTransient<IRatingRepository>(provider => new RatingRepository(serverName, databaseName, userName, password));

            return services;
        }

    }
}
