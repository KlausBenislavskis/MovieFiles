using Microsoft.Extensions.DependencyInjection;
using MovieFiles.Api.Client.Services;

namespace MovieFiles.Infrastructure
{
    public static class ClientServicesExtensions
    {
        public static IServiceCollection AddMovieFilesClient(this IServiceCollection services,string apiUrl, string appKey)
        {
            services.AddTransient<IRatingService>(provider => new RatingService(apiUrl, appKey));
            services.AddTransient<IMoviesService>(provider => new MoviesService(apiUrl, appKey));

            return services;
        }

    }
}
