using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MovieFiles.Adapters.Services;
using MovieFiles.Api.Client.Services;
using MovieFiles.Api.Functions;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Services;
using MovieFiles.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using MovieFiles.Infrastructure.Repositories;

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
            string movieDbApiToken = Environment.GetEnvironmentVariable("MOVIE_API_TOKEN");
            
            builder.Services.AddInfrastructure(dbServer,dbName,dbUser,dbPass);
            builder.Services.AddScoped<IMoviesService>(provider => new MoviesService(movieDbApiToken));
            builder.Services.AddScoped<IMovieDetailsService>(provider => new MovieDetailsService(movieDbApiToken));
            builder.Services.AddScoped<IMovieUtilService>(provider => new MovieUtilService(movieDbApiToken));
            builder.Services.AddScoped<IPeopleService>(provider => new PeopleServices(movieDbApiToken));
            builder.Services.AddScoped<IRatingService>(provider => new RatingService(provider.GetService<IRatingRepository>(), provider.GetService<IActivityRepository>()));
            builder.Services.AddScoped<ICommentService>(provider => new CommentService(provider.GetService<ICommentRepository>(), provider.GetService<IActivityRepository>()));
        }
    }
}
