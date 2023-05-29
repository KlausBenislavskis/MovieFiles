using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Interfaces.Statistics;
using MovieFiles.Core.Models;

namespace MovieFiles.Api.Functions;

public class StatisticsFunctions
{
    private readonly ILogger<MovieLists> _logger;
    private readonly IMovieStatisticsRepository _movieStatisticsRepository;

    public StatisticsFunctions(ILogger<MovieLists> log, IMovieStatisticsRepository movieStatisticsRepository)
    {
        _logger = log;
        _movieStatisticsRepository = movieStatisticsRepository;
    }

    [FunctionName("GetMovieStatistics")]
    [OpenApiOperation(operationId: "GetMovieStatistics", tags: new[] { "Statistics" })]
    [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
        Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(MovieStatistics),
        Description = "The OK response")]
    public async Task<IActionResult> GetMovieStatistics(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/{movieId:int}/statistics")]
        HttpRequest req, int movieId)
    {
        var count = await _movieStatisticsRepository.GetAllStatisticsMovieListAsync(movieId);
        return new OkObjectResult(count);
    }
    
    [FunctionName("GetMovieWatchLaterStatistics")]
    [OpenApiOperation(operationId: "GetMovieWatchLaterStatistics", tags: new[] { "Statistics" })]
    [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
        Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(int),
        Description = "The OK response")]
    public async Task<IActionResult> GetMovieWatchLaterStatistics(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/{movieId:int}/statistics/watch_later")]
        HttpRequest req, int movieId)
    {
        var count = await _movieStatisticsRepository.GetStatisticsWatchLaterMovieAsync(movieId);
        return new OkObjectResult(count);
    }
    
    [FunctionName("GetMovieAlreadyWatchedStatistics")]
    [OpenApiOperation(operationId: "GetMovieAlreadyWatchedStatistics", tags: new[] { "Statistics" })]
    [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
        Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(int?),
        Description = "The OK response")]
    public async Task<IActionResult> GetMovieAlreadyWatchedStatistics(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/{movieId:int}/statistics/already_watched")]
        HttpRequest req, int movieId)
    {
        var count = await _movieStatisticsRepository.GetStatisticsAlreadyWatchedMovieAsync(movieId);
        return new OkObjectResult(count);
    }
    
    [FunctionName("GetMovieTopListStatistics")]
    [OpenApiOperation(operationId: "GetMovieTopListStatistics", tags: new[] { "Statistics" })]
    [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
    [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string),
        Description = "The function key")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(int),
        Description = "The OK response")]
    public async Task<IActionResult> GetMovieTopListStatistics(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movie/{movieId:int}/statistics/top_list")]
        HttpRequest req, int movieId)
    {
        var count = await _movieStatisticsRepository.GetStatisticsFavoriteMovieAsync(movieId);
        return new OkObjectResult(count);
    }
    
}