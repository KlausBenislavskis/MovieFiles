using Microsoft.Extensions.DependencyInjection;
using MovieFiles.Api.Client.Services;
using MovieFiles.Core.Interfaces;

namespace MovieFiles.Infrastructure
{
    public static class ClientServicesExtensions
    {
        public static IServiceCollection AddMovieFilesClient(this IServiceCollection services,string apiUrl, string appKey)
        {
            
            services.AddScoped<IRatingService>(provider => new RatingService(apiUrl, appKey));
            services.AddScoped<IUserService>(provider => new UserService(apiUrl, appKey));
            services.AddScoped<IMoviesService>(provider => new MoviesService(apiUrl, appKey));
          
            return services;
        }

    }
}
