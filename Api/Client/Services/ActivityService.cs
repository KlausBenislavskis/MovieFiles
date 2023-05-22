using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MovieFiles.Api.Client.Services
{
    internal class ActivityService : BaseService, IActivityService
    {
        public ActivityService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task<List<BaseActivity>> GetActivities(Guid userId, int page = 1, int pageSize = 25)
        {
            var jsonString = await _client.GetActivitiesAsync(userId, page, pageSize,_functionAppKey);
            if (string.IsNullOrEmpty(jsonString))
            {
                return null;
            }
            var activities = JsonConvert.DeserializeObject<List<BaseActivity>>(jsonString, new BaseActivityConverter());

            return activities;
        }
    }
}
