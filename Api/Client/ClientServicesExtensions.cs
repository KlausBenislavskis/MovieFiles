using Microsoft.Extensions.DependencyInjection;
using MovieFiles.Api.Client.Services;
using MovieFiles.Api.Client.Services.Interfaces;
using IMoviesService = MovieFiles.Core.Interfaces.IMoviesService;
using IRatingService = MovieFiles.Api.Client.Services.IRatingService;

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
