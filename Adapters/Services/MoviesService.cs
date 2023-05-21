using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using System.Net.Http.Headers;
using System.Web;

namespace MovieFiles.Adapters.Services
{
   public class MoviesService : IMoviesService
    {
        private readonly HttpClient _httpClient;
        private const string Language = "en-US";

        public MoviesService(string apiToken)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",apiToken );
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            => await GetMoviesAsync($"movie/now_playing?language={Language}-US&page={page}");

        public async Task<MovieList> GetPopularMoviesAsync(int page)
            => await GetMoviesAsync($"movie/popular?language={Language}&page={page}");

        public async Task<MovieList> GetTopRatedMoviesAsync(int page)
            => await GetMoviesAsync($"movie/top_rated?language={Language}&page={page}");

        public async Task<MovieList> GetUpcomingMoviesAsync(int page)
            => await GetMoviesAsync($"movie/upcoming?language={Language}&page={page}");

        public async Task<MovieList> SearchForMovies(string name, int page)
        {
            return await GetMoviesAsync($"search/movie?page={page}&query={name}");
        }

        public async Task<MovieList> FilterMovies(int? highYear, int? lowYear, string cast, string crew, string genres, int page)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            if (lowYear != null){
                parameters["primary_release_date.gte"] = lowYear.ToString();
            }
            if (highYear != null){
                parameters["primary_release_date.lte"] = highYear.ToString();
            }
            if (!String.IsNullOrWhiteSpace(cast)){
                parameters["with_cast"] = cast;
            }
            if (!String.IsNullOrWhiteSpace(crew)){
                parameters["with_crew"] = crew;
            }
            if (!String.IsNullOrWhiteSpace(genres)){
                parameters["with_genres"] = genres;
            }
            parameters["page"] = page.ToString();
            return await GetMoviesAsync($"discover/movie?" + parameters.ToString());
        }
    }
}
