using MovieFiles.Api.Client.Mappers;
using MovieFiles.Core.Interfaces;

namespace MovieFiles.Api.Client.Services
{
    public class MoviesService : BaseService, IMoviesService
    {
        public MoviesService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task<Core.Models.MovieList> GetPopularMoviesAsync(int page)
        {
            var response = await RetryHelper.RetryOnExceptionAsync<MovieList>(3, () => _client.GetPopularMoviesAsync(page, _functionAppKey));
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> GetNowPlayingMoviesAsync(int page)
        {
            var response = await RetryHelper.RetryOnExceptionAsync<MovieList>(3, () => _client.GetNowPlayingMoviesAsync(page, _functionAppKey));
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> GetTopRatedMoviesAsync(int page)
        {
            var response = await RetryHelper.RetryOnExceptionAsync<MovieList>(3, () => _client.GetTopRatedMoviesAsync(page, _functionAppKey));
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> GetUpcomingMoviesAsync(int page)
        {
            var response = await RetryHelper.RetryOnExceptionAsync<MovieList>(3, () => _client.GetUpcomingMoviesAsync(page, _functionAppKey));
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> SearchForMovies(string name, int page)
        {
            var response = await RetryHelper.RetryOnExceptionAsync<MovieList>(3, () => _client.MovieFilterAsync(name, page, _functionAppKey));
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> FilterMovies(int? highYear, int? lowYear, string cast, string crew, string genres, int page)
        {
            var response = await _client.MovieDiscoverAsync(lowYear,highYear,cast,crew,genres,page,_functionAppKey);
            return ClientToUi.Map(response);
        }
    }
}
