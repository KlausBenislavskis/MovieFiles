using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieFiles.Api.Functions
{
    public class Activities
    {
        private readonly ILogger<Activities> _logger;
        private readonly IActivityRepository _activityRepository;

        public Activities(ILogger<Activities> log, IActivityRepository activityRepository)
        {
            _logger = log;
            _activityRepository = activityRepository;
        }

        [FunctionName("GetActivities")]
        [OpenApiOperation(operationId: "GetActivities", tags: new[] { "Activities" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Query, Required = true, Type = typeof(Guid))]
        [OpenApiParameter(name: "page", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "Page number")]
        [OpenApiParameter(name: "pageSize", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "Number of records per page")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]

        public async Task<IActionResult> GetActivities(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "activities")] HttpRequest req)
        {
            if (!Guid.TryParse(req.Query["userId"], out var userId))
            {
                return new BadRequestObjectResult("Invalid user ID.");
            }

            int.TryParse(req.Query["page"], out var page);
            int.TryParse(req.Query["pageSize"], out var pageSize);

            _logger.LogInformation($"GetActivities function processed a request for user {userId}.");

            var activities = await _activityRepository.GetActivities(userId, page, pageSize);

            if (activities == null || activities.Count == 0)
            {
                return new NotFoundResult();
            }

            var settings = new JsonSerializerSettings
            {
                //TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() }
            };

            string json = JsonConvert.SerializeObject(activities, settings);

            // Handling this with json because activities is an abstract object
            return new OkObjectResult(json);
        }
    }
}
