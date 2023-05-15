
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

using Microsoft.OpenApi.Models;
using System.Net.Http;
using System.Text.Json;
using MovieFiles.Core.Models;
using MovieFiles.Core.Interfaces;


namespace MovieFiles.Api.Functions.Movies;

public class MoviesFunction
{

    private readonly IMoviesService _moviesService;
    
    public MoviesFunction(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }
    
    [FunctionName("GetLatestMovies")]
    [OpenApiOperation(operationId: "GetLatestMovies", tags: new[] { "Movies" })]
    [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IList<Movie>), Description = "The OK response")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(HttpResponseMessage), Description = "The Bad Request response")]
    public async Task<(IList<Movie>?, HttpResponseMessage?)> GetLatestMovies()
    {
       return await _moviesService.GetLatestMoviesAsync();
    }
    
    [FunctionName("GetNowPlayingMovies")]
    [OpenApiOperation(operationId: "GetNowPlayingMovies", tags: new[] { "Movies" })]
    [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IList<Movie>), Description = "The OK response")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(HttpResponseMessage), Description = "The Bad Request response")]
    public async Task<(IList<Movie>?, HttpResponseMessage?)> GetNowPlayingMoviesAsync()
    {
        return await _moviesService.GetNowPlayingMoviesAsync();
    }
    
    [FunctionName("GetPopularMovies")]
    [OpenApiOperation(operationId: "GetPopularMovies", tags: new[] { "Movies" })]
    [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IList<Movie>), Description = "The OK response")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(HttpResponseMessage), Description = "The Bad Request response")]
    public async Task<(IList<Movie>?, HttpResponseMessage?)> GetPopularMoviesAsync()
    {
        return await _moviesService.GetPopularMoviesAsync();
    }
    
    [FunctionName("GetTopRatedMovies")]
    [OpenApiOperation(operationId: "GetTopRatedMovies", tags: new[] { "Movies" })]
    [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IList<Movie>), Description = "The OK response")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(HttpResponseMessage), Description = "The Bad Request response")]
    public async Task<(IList<Movie>?, HttpResponseMessage?)> GetTopRatedMoviesAsync()
    {
        return await _moviesService.GetTopRatedMoviesAsync();
    }
    
    [FunctionName("GetUpcomingMovies")]
    [OpenApiOperation(operationId: "GetUpcomingMovies", tags: new[] { "Movies" })]
    [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IList<Movie>), Description = "The OK response")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(HttpResponseMessage), Description = "The Bad Request response")]
    public async Task<(IList<Movie>?, HttpResponseMessage?)> GetUpcomingMoviesAsync()
    {
        return await _moviesService.GetUpcomingMoviesAsync();
    }
    
    
}