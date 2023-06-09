﻿using MovieFiles.Api.Client.Mappers;

namespace MovieFiles.Api.Client.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task ResolveUser(Guid userId, string username)
        {
            try
            {
                await _client.ResolveUserAsync(userId, username, _functionAppKey);
            }
            //Can happen if reloading page 10x fast
            catch (ApiException e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task<List<Core.Models.User>> SearchUsersByName(string username)
        {
            try
            {
                return (await _client.SearchUsersByNameAsync(username, _functionAppKey)).Select(ClientToUi.Map)
                    .ToList();
            }
            catch (ApiException ex)
            {
                //No comments found for a movie
                return new List<Core.Models.User>();
            }
        }

        public async Task<List<Core.Models.User>> GetFollowing(Guid userId)
        {
            try
            {
                return (await _client.GetFollowingUsersAsync(userId, _functionAppKey)).Select(ClientToUi.Map)
                    .ToList();
            }
            catch (ApiException ex)
            {
                // No comments found for a movie
                return new List<Core.Models.User>();
            }
        }

        public async Task<List<Core.Models.User>> GetFollowers(Guid userId)
        {
            try
            {
                return (await _client.GetFollowersAsync(userId, _functionAppKey)).Select(ClientToUi.Map)
                    .ToList();
            }
            catch (ApiException ex)
            {
                // No comments found for a movie
                return new List<Core.Models.User>();
            }
        }

        public Task Follow(Guid userId, Guid followingUserId)
        {
            try
            {
                return _client.FollowUserAsync(userId, followingUserId, _functionAppKey);
            }
            catch (ApiException ex)
            {
                // No comments found for a movie
                return Task.CompletedTask;
            }
        }

        public Task Unfollow(Guid userId, Guid followingUserId)
        {
            try
            {
                return _client.UnfollowUserAsync(userId, followingUserId, _functionAppKey);
            }
            catch (ApiException ex)
            {
                // No comments found for a movie
                return Task.CompletedTask;
            }
        }
    }
}