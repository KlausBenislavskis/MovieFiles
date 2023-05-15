using MovieFiles.Api.Client.Mappers;
using System.ComponentModel;

namespace MovieFiles.Api.Client.Services
{
    public class RatingService : BaseService, IRatingService 
    {
        public RatingService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task<Models.Rating?> GetRatingAsync(Guid userId, int movieId)
        {
            try
            {
                return ClientToUi.Map(await _client.GetRatingAsync(userId, movieId, _functionAppKey));
            }
            //Found no rating 
            catch (ApiException e)
            {
                return null;
            }
        }
        public async Task<double?> GetAverageRating(int movieId)
        {
            try
            {
                return await _client.GetAverageRatingAsync(movieId, _functionAppKey);
            }
            //Found no rating 
            catch (ApiException e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Models.Rating>> GetRatingsByUserAsync(Guid userId)
        {
            return (await _client.GetRatingsByUserAsync(userId, _functionAppKey))?.Select(ClientToUi.Map) ?? new List<Models.Rating>();
        }

        public async Task<IEnumerable<Models.Rating>> GetRatingsForMovieAsync(int movieId)
        {
            return (await _client.GetRatingsForMovieAsync(movieId, _functionAppKey))?.Select(ClientToUi.Map) ?? new List<Models.Rating>();
        }

        public async Task SetRatingAsync(Models.Rating rating)
        {
            await _client.AddRatingAsync(_functionAppKey, UiToClient.Map(rating));
        }


    }
}