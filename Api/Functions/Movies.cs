using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net.Http;
using System.Text.Json;
using MovieFiles.Core.Models;
using MovieFiles.Core.Interfaces;
using MovieFiles.Adapters;

namespace MovieFiles.Api.Functions
{
    public class Movies
    {
        private readonly ILogger<Movies> _logger;
        private readonly string _apiKey;
        private readonly ISearchMovies _searchMovies;

        public Movies(ILogger<Movies> log)
        {
            _logger = log;
            _apiKey = System.Environment.GetEnvironmentVariable("MOVIE_API_KEY");
            _searchMovies = new SearchMovies();
        }

        // @Nick remove this method if your function will work.
        [FunctionName("GetPopularMovies")]
        [OpenApiOperation(operationId: "GetPopularMovies", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]
        public async Task<IActionResult> GetPopularMovies(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/popular")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            
            MovieList list = await _searchMovies.GetTestingMovies(1);

            return new OkObjectResult(list);
        }

        [FunctionName("MovieFilter")]
        [OpenApiOperation(operationId: "MovieFilter", tags: new[] { "Movies" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "Name that you want to search for")]
        [OpenApiParameter(name: "page", In = ParameterLocation.Query, Required = true, Type = typeof(int), Description = "Page number that you want to see")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MovieList), Description = "The OK response")]
        public async Task<IActionResult> MovieFilter(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/name")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function  processed a request movieFileter.");

            string name = req.Query["name"];
            int page = int.Parse(req.Query["page"]);

            return new OkObjectResult(await _searchMovies.SearchForMovies(name,page));
        }
    }
}

