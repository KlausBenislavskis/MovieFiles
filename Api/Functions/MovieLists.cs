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
using System;
using System.Collections.Generic;
using MovieFiles.Core.Models;
using System.Linq;

namespace MovieFiles.Api.Functions
{
    public class MovieLists
    {
        private readonly ILogger<MovieLists> _logger;
        private readonly IMovieListRepository _movieListService;
        private readonly IMovieDetailsService _movieDetailService;

        public MovieLists(ILogger<MovieLists> log, IMovieListRepository movieListService, IMovieDetailsService movieDetailsService)
        {
            _logger = log;
            _movieListService = movieListService;
            _movieDetailService = movieDetailsService;
        }

        [FunctionName("AddMovieToMovieList")]
        [OpenApiOperation(operationId: "AddMovieToMovieList", tags: new[] { "Movie lists" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Query, Required = true, Type = typeof(Guid), Description = "Id of user that is adding movie to his list")]
        [OpenApiParameter(name: "movieId", In = ParameterLocation.Query, Required = true, Type = typeof(int), Description = "Id of movie to add to the list")]
        [OpenApiParameter(name: "movieListType", In = ParameterLocation.Query, Required = true, Type = typeof(MyMovieListItem.ListType), Description = "Type of movie list. 0: watch later, 1: toplist, 2: already watched")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "text/plain", bodyType: typeof(string), Description = "Incorrect parameters were provided.")]
        public async Task<IActionResult> AddMovieToWatchLater(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "my-movies/watch-later")] HttpRequest req)
        {
            _logger.LogInformation($"Get Movies to watch later triggered with userId {req.Query["userId"]} and movie id {req.Query["movieId"]}");

            if (!int.TryParse(req.Query["movieId"], out var movieId) && movieId <1){
                return new BadRequestObjectResult("Invalid movie ID.");
            }
            if (!Guid.TryParse(req.Query["userId"], out var userId)){
                return new BadRequestObjectResult("Invalid user ID.");
            }
            if (!Enum.TryParse<MyMovieListItem.ListType>(req.Query["movieListType"],true,out var movieListType)){
                return new BadRequestObjectResult("Invalid type of list.");
            }

            var additionSuccesful = await _movieListService.AddMovieToMyList(
                new(){
                    UserId = userId,
                    MovieId = movieId,
                    ListName = MyMovieListItem.GetListTypeName(movieListType)
                }
            );

            if (additionSuccesful){
                return new OkObjectResult("Saved");
            } else {
                return new BadRequestObjectResult("this movie already exists or it is unable to add it to the list.");
            }

            
        }

        [FunctionName("GetMoviesFromMovieList")]
        [OpenApiOperation(operationId: "GetMoviesFromMovieList", tags: new[] { "Movie lists" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Query, Required = true, Type = typeof(Guid), Description = "Id of a user to get the list of.")]
        [OpenApiParameter(name: "movieListType", In = ParameterLocation.Query, Required = true, Type = typeof(MyMovieListItem.ListType), Description = "Type of movie list. 0: watch later, 1: toplist, 2: already watched")]
        [OpenApiParameter(name: "page", In = ParameterLocation.Query, Required = true, Type = typeof(int), Description = "Page number to return.")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Core.Models.MovieList), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "text/plain", bodyType: typeof(string), Description = "Incorrect parameters were provided.")]
        public async Task<IActionResult> GetMoviesToWatchLater(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "my-movies/watch-later")] HttpRequest req)
        {
            _logger.LogInformation($"Get Movies to watch later triggered with userId {req.Query["userId"]}");

            if (!Guid.TryParse(req.Query["userId"], out var userId)){
                return new BadRequestObjectResult("Invalid user ID.");
            }

            if (!int.TryParse(req.Query["page"], out var page) && page <1){
                return new BadRequestObjectResult("Invalid page number.");
            }
            if (!Enum.TryParse<MyMovieListItem.ListType>(req.Query["movieListType"],true,out var movieListType)){
                return new BadRequestObjectResult("Invalid type of list.");
            }

            CustomMovieList<MyMovieListItem> list = await _movieListService.GetMyMovieList(userId, movieListType, page);

            return new OkObjectResult(await ConvertCustomMovieListToMovieList(list));
        }

        [FunctionName("RemoveMovieFromMovieList")]
        [OpenApiOperation(operationId: "RemoveMovieFromMovieList", tags: new[] { "Movie lists" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Query, Required = true, Type = typeof(Guid), Description = "Id of user that is adding movie to his list")]
        [OpenApiParameter(name: "movieId", In = ParameterLocation.Query, Required = true, Type = typeof(int), Description = "Id of movie to add to the list")]
        [OpenApiParameter(name: "movieListType", In = ParameterLocation.Query, Required = true, Type = typeof(MyMovieListItem.ListType), Description = "Type of movie list. 0: watch later, 1: toplist, 2: already watched")]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "text/plain", bodyType: typeof(string), Description = "Incorrect parameters were provided.")]
        public async Task<IActionResult> RemoveMovieToWatchLater(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "my-movies/watch-later")] HttpRequest req)
        {
            _logger.LogInformation($"Get Movies to watch later triggered with userId {req.Query["userId"]} and movie id {req.Query["movieId"]}");

            if (!int.TryParse(req.Query["movieId"], out var movieId) && movieId <1){
                return new BadRequestObjectResult("Invalid movie ID.");
            }
            if (!Guid.TryParse(req.Query["userId"], out var userId)){
                return new BadRequestObjectResult("Invalid user ID.");
            }
            if (!Enum.TryParse<MyMovieListItem.ListType>(req.Query["movieListType"],true,out var movieListType)){
                return new BadRequestObjectResult("Invalid type of list.");
            }

            var deletionSuccesfull = await _movieListService.RemoveMovieFromMyList(
                new(){
                    UserId = userId,
                    MovieId = movieId,
                    ListName = MyMovieListItem.GetListTypeName(movieListType)
                }
            );

            if (deletionSuccesfull){
                return new OkObjectResult("Deleted");
            } else {
                return new NotFoundObjectResult("Unable to find resource to delete");
            }
        }

        private async Task<Core.Models.MovieList> ConvertCustomMovieListToMovieList(CustomMovieList<Core.Models.MyMovieListItem> externList)
        {
            Core.Models.MovieList myList = new()
            {
                Page = externList.Page,
                TotalResults = externList.TotalResults,
                TotalPages = externList.TotalPages
            };
            var getMoviesTasks = externList.List.Select(getMovieFromListItem).ToArray();
            myList.Results = await Task.WhenAll(getMoviesTasks);
            return myList;
        }

        private async Task<Core.Models.Movie> getMovieFromListItem(Core.Models.MyMovieListItem item){
            return await _movieDetailService.GetMovieDetailsAsync(item.MovieId);
        }
    }
}

