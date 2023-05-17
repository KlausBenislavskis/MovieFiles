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

        public Task<Core.Models.MovieList> GetNowPlayingMoviesAsync(int page)
        {
            throw new NotImplementedException();
        }
        public Task<Core.Models.MovieList> GetTopRatedMoviesAsync(int page)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Models.MovieList> GetUpcomingMoviesAsync(int page)
        {
            throw new NotImplementedException();
        }

        public async Task<Core.Models.MovieList> SearchForMovies(string name, int page)
        {
            var response = await _client.MovieFilterAsync(name,page,_functionAppKey);
            return ClientToUi.Map(response);
        }
    }
}