using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models.People;
using System.Net;
using System.Threading.Tasks;

namespace MovieFiles.Api.Functions
{
    public class People
    {
        private readonly ILogger<People> _logger;
        private readonly IPeopleService _peopleService;

        public People(ILogger<People> log, IPeopleService peopleService)
        {
            _logger = log;
            _peopleService = peopleService;
        }

        [FunctionName("GetPopularPeople")]
        [OpenApiOperation(operationId: "PopularPeople", tags: new[] { "people" })]
        [OpenApiParameter(name: "page", In = ParameterLocation.Query, Required = true, Type = typeof(int), Description = "Page number that you want to see")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(PeopleList), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/popular")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (!int.TryParse(req.Query["page"], out var page))
            {
                return new BadRequestObjectResult("invalid page number entered");
            }

            return new OkObjectResult(await _peopleService.GetPopularPeople(page));
        }

        [FunctionName("SearchPeople")]
        [OpenApiOperation(operationId: "SearchPeople", tags: new[] { "people" })]
        [OpenApiParameter(name: "query", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "name to search for in people")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(PeopleList), Description = "The OK response")]
        public async Task<IActionResult> SearchPeople(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "search/person")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string query = req.Query["query"];

            return new OkObjectResult(await _peopleService.SearchPeople(query));
        }
    }
}

