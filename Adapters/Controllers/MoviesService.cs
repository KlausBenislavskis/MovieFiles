using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Adapters.Controllers
{
   
    public class MoviesService : IMovieRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MoviesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

      
        public async Task<IActionResult> GetLatestMoviesAsync(String apiKey)
        {
        
            // Set the endpoint URL
            string url = $"https://api.themoviedb.org/3/movie/latest?api_key={apiKey}&language=en-US&page=1";

            HttpClient client = _httpClientFactory.CreateClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    
        public async Task<IActionResult> GetNowPlayingMoviesAsync(String apiKey)
        {
        
            // Set the endpoint URL
            string url = $"https://api.themoviedb.org/3/movie/now_playing?api_key={apiKey}&language=en-US&page=1";

            HttpClient client = _httpClientFactory.CreateClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    
        public async Task<IActionResult> GetPopularMoviesAsync(String apiKey)
        {
        
            // Set the endpoint URL
            string url = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=en-US&page=1";

            HttpClient client = _httpClientFactory.CreateClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        public async Task<IActionResult> GetTopRatedMoviesAsync(String apiKey)
        {
    
            // Set the endpoint URL
            string url = $"https://api.themoviedb.org/3/movie/top_rated?api_key={apiKey}&language=en-US&page=1";

            HttpClient client = _httpClientFactory.CreateClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        public async Task<IActionResult> GetUpcomingMoviesAsync(String apiKey)
        {
            string url = $"https://api.themoviedb.org/3/movie/upcoming?api_key={apiKey}&language=en-US&page=1";

            // Set the endpoint URL
            HttpClient client = _httpClientFactory.CreateClient();
        
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}