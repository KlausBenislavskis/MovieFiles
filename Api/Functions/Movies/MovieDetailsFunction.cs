using System;
using MovieFiles.Core.Interfaces;
using System.Net;
using System.Threading.Tasks;
using LinqToDB.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Models;


namespace MovieFiles.Api.Functions.Movies;

public class MovieDetailsFunction
{
    private readonly ILogger<Ratings> _logger;
    private readonly IMovieDetailsService _movieDetailsService;

    public MovieDetailsFunction(ILogger<Ratings> log, IMovieDetailsService movieDetailsService)
    {
        _logger = log;
        _movieDetailsService = movieDetailsService;
    }
    
    // For GetMovieDetails:
    [FunctionName("GetMovieDetails")]
    [OpenApiOperation(operationId: "GetMovieDetails", tags: new[] { "MovieDetails" })]
    [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = false, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
        Description = "The function key")]
   [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Movie), Description = "The OK response")]
    public async Task<IActionResult> GetMovieDetails(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/{movieId}")] HttpRequest req, int movieId)
    {
        return new OkObjectResult(await _movieDetailsService.GetMovieDetailsAsync(movieId));
    }
    
    
    
    
    
}