using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using System.Net;
using System.Threading.Tasks;

namespace MovieFiles.Api.Functions
{
    public class MoviesFunction
    {

        private readonly IMoviesService _moviesService;

        public MoviesFunction(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }


        // For GetNowPlayingMoviesAsync:
        [FunctionName("GetNowPlayingMovies")]
        [OpenApiOperation(operationId: "GetNowPlayingMovies", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
            Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]

        public async Task<IActionResult> GetNowPlayingMovies(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movies/now-playing/{page}")] HttpRequest req, int page = 1)
        {
            return new OkObjectResult(await _moviesService.GetNowPlayingMoviesAsync(page));
        }

        // For GetPopularMoviesAsync:
        [FunctionName("GetPopularMovies")]
        [OpenApiOperation(operationId: "GetPopularMovies", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
            Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]


        public async Task<IActionResult> GetPopularMovies(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movies/popular/{page}")] HttpRequest req, int page = 1)
        {
            return new OkObjectResult(await _moviesService.GetPopularMoviesAsync(page));
        }

        // For GetTopRatedMoviesAsync:
        [FunctionName("GetTopRatedMovies")]
        [OpenApiOperation(operationId: "GetTopRatedMovies", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
            Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]

        public async Task<IActionResult> GetTopRatedMovies(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movies/top-rated/{page}")] HttpRequest req, int page = 1)
        {
            return new OkObjectResult(await _moviesService.GetTopRatedMoviesAsync(page));
        }

        // For GetUpcomingMoviesAsync:
        [FunctionName("GetUpcomingMovies")]
        [OpenApiOperation(operationId: "GetUpcomingMovies", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
            Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]
        public async Task<IActionResult> GetUpcomingMovies(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movies/upcoming/{page}")] HttpRequest req, int page = 1)
        {
            return new OkObjectResult(await _moviesService.GetUpcomingMoviesAsync(page));
        }

        [FunctionName("MovieFilter")]
        [OpenApiOperation(operationId: "MovieFilter", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "Name that you want to search for")]
        [OpenApiParameter(name: "page", In = ParameterLocation.Query, Required = true, Type = typeof(int), Description = "Page number that you want to see")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]
        public async Task<IActionResult> MovieFilter(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movies/name")] HttpRequest req)
        {

            string name = req.Query["name"];
            int page = int.Parse(req.Query["page"]);

            return new OkObjectResult(await _moviesService.SearchForMovies(name, page));
        }

        [FunctionName("DiscoverMovies")]
        [OpenApiOperation(operationId: "MovieDiscover", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "minPrimaryReleaseData", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "Lowes year to find")]
        [OpenApiParameter(name: "maxPrimaryReleaseData", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "Highest year of release to find")]
        [OpenApiParameter(name: "cast", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "person that should be part of cast")]
        [OpenApiParameter(name: "crew", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "person that should be part of crew")]
        [OpenApiParameter(name: "genres", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "genre that movies should have")]
        [OpenApiParameter(name: "page", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "Page number that you want to see")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]
        public async Task<IActionResult> MovieDiscover(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movies/discover")] HttpRequest req)
        {
            int? yearLow = null;
            if (int.TryParse(req.Query["minPrimaryReleaseData"], out var minReleaseDate)){
                yearLow = minReleaseDate;
            }
            int? yearHigh = null;
            if (int.TryParse(req.Query["maxPrimaryReleaseData"], out var maxReleaseDate)){
                yearHigh = maxReleaseDate;
            }
            string cast = req.Query["cast"];
            string crew = req.Query["crew"];
            string genres = req.Query["genres"];

            int page = 1;
            if (int.TryParse(req.Query["page"],out var pageInput) && pageInput>0){
                page = pageInput;
            }

            return new OkObjectResult(await _moviesService.FilterMovies(yearHigh,yearLow,cast,crew,genres,page));
        }
    }
}