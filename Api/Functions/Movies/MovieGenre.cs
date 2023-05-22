using System.IO;
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
using Newtonsoft.Json;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using System.Collections.Generic;

namespace MovieFiles.Api.Functions.Movies
{
    public class MovieGenre
    {
        private readonly ILogger<MovieGenre> _logger;
        private readonly IMovieUtilService _utilService;

        public MovieGenre(ILogger<MovieGenre> log, IMovieUtilService utilService)
        {
            _logger = log;
            _utilService = utilService;
        }

        [FunctionName("MovieGenre")]
        [OpenApiOperation(operationId: "GetAllGenre", tags: new[] { "Genre" })]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(GenreList), Description = "The OK response")]
        public async Task<IActionResult> GetAllGenre(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request to get all genre.");

            return new OkObjectResult(await _utilService.GetGenresAsync());
        }
    }
}

