using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieFiles.Api.Functions
{
    public class Comments
    {
        private readonly ILogger<Comments> _logger;
        private readonly ICommentRepository _commentRepository;

        public Comments(ILogger<Comments> log, ICommentRepository commentRepository)
        {
            _logger = log;
            _commentRepository = commentRepository;
        }
        [FunctionName("GetComments")]
        [OpenApiOperation(operationId: "GetComments", tags: new[] { "Comments" })]
        [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiParameter(name: "page", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Core.Models.Comment>))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> GetComments(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "comments/{movieId}/{page}")] HttpRequest req,
            string movieId, string page)
        {
            _logger.LogInformation($"GetComments function processed a request for movie {movieId} on page {page}.");

            if (!int.TryParse(movieId, out var movieIdParsed) || !int.TryParse(page, out var pageParsed))
            {
                return new BadRequestObjectResult("Invalid movie ID or page number.");
            }

            var comments = await _commentRepository.GetComments(movieIdParsed, pageParsed);

            if (comments?.Any() ?? false)
            {
                return new OkObjectResult(comments);

            }
            return new NotFoundResult();

        }


        [FunctionName("Comment")]
        [OpenApiOperation(operationId: "Comment", tags: new[] { "Comments" })]
        [OpenApiParameter(name: "movieId", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Core.Models.Comment))]
        [OpenApiRequestBody("application/json", typeof(Core.Models.Comment), Description = "The comment to be posted")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> Comment(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "comments/{movieId}/{userId}")] HttpRequest req,
            string movieId, string userId)
        {
            _logger.LogInformation($"Comment function processed a request for movie {movieId} by user {userId}.");

            if (!int.TryParse(movieId, out var movieIdParsed) || !Guid.TryParse(userId, out var userIdParsed))
            {
                return new BadRequestObjectResult("Invalid movie ID or user ID.");
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var commentData = JsonConvert.DeserializeObject<Core.Models.Comment>(requestBody);

            if (commentData == null)
            {
                return new BadRequestObjectResult("Invalid comment data.");
            }

            await _commentRepository.Comment(commentData, movieIdParsed, userIdParsed);

            return new OkResult();
        }



    }
}
