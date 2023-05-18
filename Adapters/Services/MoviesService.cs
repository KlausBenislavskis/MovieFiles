using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using System.Net.Http.Headers;

namespace MovieFiles.Adapters.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private const string Language = "en-US";

        public MoviesService(string apiKey)
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiKey = apiKey;
        }

        private async Task<MovieList> GetMoviesAsync(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                return new MovieList();
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
            MovieList? movieList = MovieApiUtil.ConvertApiMessage<MovieList>(jsonResponse);

            return movieList ?? new MovieList();

        }

        public async Task<MovieList> GetNowPlayingMoviesAsync(int page)
            => await GetMoviesAsync($"movie/now_playing?api_key={_apiKey}&language={Language}-US&page={page}");

        public async Task<MovieList> GetPopularMoviesAsync(int page)
            => await GetMoviesAsync($"movie/popular?api_key={_apiKey}&language={Language}&page={page}");

        public async Task<MovieList> GetTopRatedMoviesAsync(int page)
            => await GetMoviesAsync($"movie/top_rated?api_key={_apiKey}&language={Language}&page={page}");

        public async Task<MovieList> GetUpcomingMoviesAsync(int page)
            => await GetMoviesAsync($"movie/upcoming?api_key={_apiKey}&language={Language}&page={page}");

        public async Task<MovieList> SearchForMovies(string name, int page)
        {
            if (string.IsNullOrEmpty(_apiKey) || page < 1)
            {
                return new MovieList();
            }
            return await GetMoviesAsync($"search/movie?api_key={_apiKey}&page={page}&query={name}");
        }
    }
}
