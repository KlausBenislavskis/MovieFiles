using MovieFiles.Api.Client.Mappers;
using MovieFiles.Core.Interfaces;

namespace MovieFiles.Api.Client.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MovieFilesFunctions _client;
        private readonly string _functionAppKey;

        public MoviesService(string httpUrl, string functionAppKey)
        {
            _client = new MovieFilesFunctions(new HttpClient { BaseAddress = new Uri(httpUrl) });
            _client.BaseUrl = httpUrl;
            _functionAppKey = functionAppKey;
        }

        public async Task<Core.Models.MovieList> GetPopularMoviesAsync(int page)
        {
            var response = await _client.GetPopularMoviesAsync(page, _functionAppKey);
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> GetNowPlayingMoviesAsync(int page)
        {
            var response = await _client.GetNowPlayingMoviesAsync(page, _functionAppKey);
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> GetTopRatedMoviesAsync(int page)
        {
            var response = await _client.GetTopRatedMoviesAsync(page, _functionAppKey);
            return ClientToUi.Map(response);
        }

        public async Task<Core.Models.MovieList> GetUpcomingMoviesAsync(int page)
        {
            var response = await _client.GetUpcomingMoviesAsync(page, _functionAppKey);
            return ClientToUi.Map(response);
        }

        public Task<Core.Models.MovieList> SearchForMovies(string name, int page)
        {
            throw new NotImplementedException();
        }
    }
}