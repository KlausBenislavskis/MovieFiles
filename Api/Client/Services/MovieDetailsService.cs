
using MovieFiles.Api.Client.Mappers;
using MovieFiles.Core.Interfaces;

namespace MovieFiles.Api.Client.Services
{
    public class MovieDetailsService : BaseService, IMovieDetailsService
    {
        public MovieDetailsService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task<Core.Models.Movie?> GetMovieDetailsAsync(int movieId)
        {
            var response = await RetryHelper.RetryOnExceptionAsync<Movie>(3, () => _client.GetMovieDetailsAsync(movieId, _functionAppKey));
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.CreditList?> GetMovieCreditsAsync(int movieId)
        {
            var response = await RetryHelper.RetryOnExceptionAsync<CreditList>(3, () => _client.GetMovieCreditsAsync(movieId, _functionAppKey));
            return ClientToUi.Map(response);
        }

        public async Task<List<string>> GetMovieLists(Guid userId, int movieId){
            var response = await RetryHelper.RetryOnExceptionAsync(3, () => _client.GetMovieListTypesAsync(userId,movieId,_functionAppKey));
            return ClientToUi.Map(response);
        }
    }
}
