using System.Net.Http.Headers;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MovieFiles.Adapters.Services
{
   
    public class MoviesService : IMoviesService
    {
        private static String API_KEY = "MOVIE_API_KEY";
        private String _apiKey;
        
        private readonly HttpClient _httpClient;
        private readonly String language = "en-US";
        private readonly int page = 1;
   
        public MoviesService()
        { 
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiKey = System.Environment.GetEnvironmentVariable(API_KEY);
        }

      
        public async  Task<(IList<Movie>?, HttpResponseMessage?)> GetLatestMoviesAsync()
        {
            string endpoint = $"movie/latest?api_key={_apiKey}&language={language}-US&page={page}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                IList<Movie>? movieResponse = JsonConvert.DeserializeObject<IList<Movie>>(jsonResponse,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                );
                
                return  (movieResponse, null);
            }
            // throw new Exception($"Failed to fetch the latest movies. StatusCode: {response.StatusCode}");
                return (null, response);
        }

    
        public async Task<(IList<Movie>?, HttpResponseMessage?)> GetNowPlayingMoviesAsync()
        {
            // Set the endpoint URL
            string endpoint = $"movie/now_playing?api_key={_apiKey}&language={language}-US&page={page}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                IList<Movie>? movieResponse = JsonConvert.DeserializeObject<IList<Movie>>(jsonResponse,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                );
                
                return  (movieResponse, null);
            }
               // throw new Exception($"Failed to fetch the latest movies. StatusCode: {response.StatusCode}");
                return (null, response);
            
        }

    
        public async Task<(IList<Movie>?, HttpResponseMessage?)> GetPopularMoviesAsync()
        {
            string endpoint = $"movie/latest?api_key={_apiKey}&language={language}&page={page}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                IList<Movie>? movieResponse = JsonConvert.DeserializeObject<IList<Movie>>(jsonResponse,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                );
                
                return  (movieResponse, null);
            }
              //  throw new Exception($"Failed to fetch the popular movies. StatusCode: {response.StatusCode}");
                return (null, response);
            
        }

        public async Task<(IList<Movie>?, HttpResponseMessage?)> GetTopRatedMoviesAsync()
        {
            
            string endpoint = $"movie/top_rated?api_key={_apiKey}&language={language}&page={page}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                IList<Movie>? movieResponse = JsonConvert.DeserializeObject<IList<Movie>>(jsonResponse,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                );
                
                return  (movieResponse, null);
            }
               // throw new Exception($"Failed to fetch the latest movies. StatusCode: {response.StatusCode}");
                return (null, response);
            
        }

        public async Task<(IList<Movie>?, HttpResponseMessage?)> GetUpcomingMoviesAsync()
        {
            string endpoint = $"movie/upcoming?api_key={_apiKey}&language={language}&page={page}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                IList<Movie>? movieResponse = JsonConvert.DeserializeObject<IList<Movie>>(jsonResponse,
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }
                );
                
                return  (movieResponse, null);
            }
               // throw new Exception($"Failed to fetch the upcoming movies. StatusCode: {response.StatusCode}");
                return (null, response);
            
        }
    }
}