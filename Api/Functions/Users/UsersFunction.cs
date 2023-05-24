using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieFiles.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieFiles.Api.Functions
{
    public class Users
    {
        private readonly ILogger<Users> _logger;
        private readonly IUserRepository _userRepository;

        public Users(ILogger<Users> log, IUserRepository userRepository)
        {
            _logger = log;
            _userRepository = userRepository;
        }

        [FunctionName("ResolveUser")]
        [OpenApiOperation(operationId: "ResolveUser", tags: new[] { "Users" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiParameter(name: "username", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(void))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        
        public async Task<IActionResult> ResolveUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users/resolve/{userId}/{username}")] HttpRequest req,
            string userId,
            string username)
        {
            _logger.LogInformation($"ResolveUser function processed a request for user {userId}.");
        
            // Convert string parameter to Guid
            if (!Guid.TryParse(userId, out var userIdGuid))
            {
                return new BadRequestObjectResult("Invalid user ID.");
            }
        
            await _userRepository.ResolveUser(userIdGuid, username);
        
            return new OkResult();
        }

        [FunctionName("SearchUsersByName")]
        [OpenApiOperation(operationId: "SearchUsersByName", tags: new[] { "Users" })]
        [OpenApiParameter(name: "username", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IList<Core.Models.User>))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        public async Task<IActionResult> SearchUsersByName(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/search/{username}")] HttpRequest req,
            string userName)
        {
        
            var users = await _userRepository.GetUsersByName(userName);
            
            if(users == null || !users.Any())
                return new NotFoundResult();
            
            return new OkObjectResult(users);
        }
        
        [FunctionName("GetFollowingUsers")]
        [OpenApiOperation(operationId: "GetFollowingUsers", tags: new[] { "Users" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IList<Core.Models.User>))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        public async Task<IActionResult> GetFollowingUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/follow/{userId}")] HttpRequest req,
            string userId)
        {
            if (!Guid.TryParse(userId, out var userIdGuid))
            {
                return new BadRequestObjectResult("Invalid user ID.");
            }
        
            var users = await _userRepository.GetFollowing(userIdGuid);
            
            if(users == null || !users.Any())
                return new NotFoundResult();
            
            return new OkObjectResult(users);
        }
        
        [FunctionName("FollowUser")]
        [OpenApiOperation(operationId: "FollowUser", tags: new[] { "Users" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiParameter(name: "followUserId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(void))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        public async Task<IActionResult> FollowUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users/follow/{userId}/{followUserId}")] HttpRequest req,
            string userId,
            string followUserId)
        {
            if (!Guid.TryParse(userId, out var userIdGuid))
            {
                return new BadRequestObjectResult("Invalid user ID.");
            }
        
            if (!Guid.TryParse(followUserId, out var followUserIdGuid))
            {
                return new BadRequestObjectResult("Invalid follow user ID.");
            }
        
            await _userRepository.Follow(userIdGuid, followUserIdGuid);
        
            return new OkResult();
        }
        
        [FunctionName("UnfollowUser")]
        [OpenApiOperation(operationId: "UnfollowUser", tags: new[] { "Users" })]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiParameter(name: "followUserId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(void))]
        [OpenApiParameter(name: "x-functions-key", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "The function key")]
        public async Task<IActionResult> UnfollowUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users/unfollow/{userId}/{followUserId}")] HttpRequest req,
            string userId,
            string followUserId)
        {
            if (!Guid.TryParse(userId, out var userIdGuid))
            {
                return new BadRequestObjectResult("Invalid user ID.");
            }
        
            if (!Guid.TryParse(followUserId, out var followUserIdGuid))
            {
                return new BadRequestObjectResult("Invalid follow user ID.");
            }
        
            await _userRepository.Unfollow(userIdGuid, followUserIdGuid);
        
            return new OkResult();
        }
        
        
    }
    
}
