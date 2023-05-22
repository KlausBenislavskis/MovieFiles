using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;

namespace MovieFiles.Api.Functions.Movies;

public class MovieDetailsFunction
{
    private readonly IMovieDetailsService _movieDetailsService;

    public MovieDetailsFunction( IMovieDetailsService movieDetailsService)
    {
        _movieDetailsService = movieDetailsService;
    }

    // For GetMovieDetails:
    [FunctionName("GetMovieDetails")]
    [OpenApiOperation(operationId: "GetMovieDetails", tags: new[] { "MovieDetails" })]
    [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
        Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Movie),
        Description = "The OK response")]
    public async Task<IActionResult> GetMovieDetails(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/{movieId:int}")]
        HttpRequest req, int movieId)
    {
        return new OkObjectResult(await _movieDetailsService.GetMovieDetailsAsync(movieId));
    }
    
    // For GetMovieCredits:
    [FunctionName("GetMovieCredits")]
    [OpenApiOperation(operationId: "GetMovieCredits", tags: new[] { "MovieDetails" })]
    [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
        Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(CreditList),
        Description = "The OK response")]
    public async Task<IActionResult> GetMovieCredits(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/{movieId}/credits")]
        HttpRequest req, int movieId)
    {
        return new OkObjectResult(await _movieDetailsService.GetMovieCreditsAsync(movieId));
    }
    
}