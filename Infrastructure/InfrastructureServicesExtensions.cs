using Microsoft.Extensions.DependencyInjection;
using MovieFiles.Core.Interfaces;
using MovieFiles.Infrastructure.Repositories;

namespace MovieFiles.Infrastructure
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string serverName, string databaseName, string userName, string password)
        {

            services.AddScoped<IRatingRepository>(provider => new RatingRepository(serverName, databaseName, userName, password));
            services.AddScoped<IUserRepository>(provider => new UserRepository(serverName, databaseName, userName, password));
            services.AddScoped<IMovieListRepository>(provider => new MovieListRepository(serverName,databaseName,userName,password));
            
            services.AddScoped<ICommentRepository>(provider => new CommentRepository(serverName, databaseName, userName, password));
            services.AddScoped<IActivityRepository>(provider => new ActivityRepository(serverName, databaseName, userName, password));

            return services;
        }

    }
}
