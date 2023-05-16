using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Newtonsoft.Json;

namespace MovieFiles.Api.Functions.Movies
{
    public class Ratings
    {
        private readonly ILogger<Ratings> _logger;
        private readonly IRatingRepository _ratingRepository;

        public Ratings(ILogger<Ratings> log, IRatingRepository ratingRepository)
        {
            _logger = log;
            _ratingRepository = ratingRepository;
        }

        [FunctionName("GetRatingsByUser")]
        [OpenApiOperation(operationId: "GetRatingsByUser", tags: new[] { "Ratings" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IEnumerable<Core.Models.Rating>))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> GetRatingsByUser(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ratings/user/{userId}")] HttpRequest req,
            string userId)
        {
            _logger.LogInformation($"GetRatingsByUser function processed a request for user {userId}.");

            // Convert string parameter to Guid
            if (!Guid.TryParse(userId, out var userIdGuid))
            {
                return new BadRequestObjectResult("Invalid user ID.");
            }

            var ratings = await _ratingRepository.GetRatingsByUserAsync(userIdGuid);

            if (ratings == null || !ratings.Any())
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(ratings);
        }

        [FunctionName("GetRatingsForMovie")]
        [OpenApiOperation(operationId: "GetRatingsForMovie", tags: new[] { "Ratings" })]
        [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IEnumerable<Core.Models.Rating>))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> GetRatingsForMovie(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ratings/movie/{movieId}")] HttpRequest req,
            string movieId)
        {
            _logger.LogInformation($"GetRatingsForMovie function processed a request for movie {movieId}.");

            // Convert string parameter to Guid
            if (!int.TryParse(movieId, out var movieIdGuid))
            {
                return new BadRequestObjectResult("Invalid movie ID.");
            }

            var ratings = await _ratingRepository.GetRatingsForMovieAsync(movieIdGuid);

            if (ratings == null || !ratings.Any())
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(ratings);
        }
        [FunctionName("GetRating")]
        [OpenApiOperation(operationId: "GetRating", tags: new[] { "Ratings" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Core.Models.Rating))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> GetRating(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "rating/{userId}/{movieId}")] HttpRequest req,
            string userId,
            string movieId)
        {
            _logger.LogInformation($"GetRating function processed a request for user {userId} and movie {movieId}.");

            // Convert string parameters to Guid
            if (!Guid.TryParse(userId, out var userIdGuid) || !int.TryParse(movieId, out var movieIdGuid))
            {
                return new BadRequestObjectResult("Invalid user ID or movie ID.");
            }

            var rating = await _ratingRepository.GetRatingAsync(userIdGuid, movieIdGuid);

            if (rating == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(rating);
        }


        [FunctionName("SetRating")]
        [OpenApiOperation(operationId: "AddRating", tags: new[] { "Ratings" })]
        [OpenApiRequestBody("application/json", typeof(Core.Models.Rating))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(Core.Models.Rating))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> AddRating(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "ratings")] HttpRequest req)
        {
            _logger.LogInformation($"AddRating function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var rating = JsonConvert.DeserializeObject<Core.Models.Rating>(requestBody);

            await _ratingRepository.SetRatingAsync(rating);

            return new CreatedResult($"ratings/{rating.UserId}/{rating.MovieId}", rating);
        }
        [FunctionName("GetAverageRating")]
        [OpenApiOperation(operationId: "GetAverageRating", tags: new[] { "Ratings" })]
        [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(double))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(void))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> GetAverageRating(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "rating/average/{movieId}")] HttpRequest req,
            string movieId)
        {
            _logger.LogInformation($"GetAverageRating function processed a request for movie {movieId}.");

            // Convert string parameters to Guid
            if (!int.TryParse(movieId, out var movieIdGuid))
            {
                return new BadRequestObjectResult("Invalid movie ID.");
            }

            var averageRating = await _ratingRepository.GetAverageRatingForMovieAsync(movieIdGuid);

            if (averageRating == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(averageRating.Value);
        }

    }
}

