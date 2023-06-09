﻿using Microsoft.Extensions.DependencyInjection;
using MovieFiles.Api.Client.Services;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Interfaces.Statistics;

namespace MovieFiles.Api.Client
{
    public static class ClientServicesExtensions
    {
        public static IServiceCollection AddMovieFilesClient(this IServiceCollection services, string apiUrl, string appKey)
        {

            services.AddScoped<IRatingService>(provider => new RatingService(apiUrl, appKey));
            services.AddScoped<IUserService>(provider => new UserService(apiUrl, appKey));
            services.AddScoped<IMoviesService>(provider => new MoviesService(apiUrl, appKey));
            services.AddScoped<IMovieDetailsService>(provider => new MovieDetailsService(apiUrl, appKey));
            services.AddScoped<IMoiveListService>(provider => new MovieListService(apiUrl,appKey,provider.GetService<IMovieDetailsService>()));
            services.AddScoped<IMovieUtilService>(prodived => new MovieUtilService(apiUrl,appKey));
            services.AddScoped<IPeopleService>(provider => new PeopleService(apiUrl,appKey));
            services.AddScoped<IMovieStatisticsService>(provider => new StatisticsService(apiUrl,appKey));
            services.AddScoped((Func<IServiceProvider, Core.Interfaces.ICommentService>)(provider => new Services.CommentService(apiUrl, appKey)));
            services.AddScoped<IActivityService>(provider => new ActivityService(apiUrl, appKey));

            return services;
        }

    }
}
