using System.Net.Http.Headers;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;

namespace MovieFiles.Adapters.Services;

public class MovieDetailsService : IMovieDetailsService
{
    private readonly HttpClient _httpClient;
    private const string Language = "en-US";

    public MovieDetailsService(string apiToken)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer",apiToken );
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    private async Task<T?> GetMovieDetailAsync<T>(string endpoint)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            return default(T);
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();
        T? result = MovieApiUtil.ConvertApiMessage<T>(jsonResponse); 
        Console.WriteLine(jsonResponse);
        return result;
    }
    
    public async Task<Movie?> GetMovieDetailsAsync(int movieId)
        => await GetMovieDetailAsync<Movie>($"movie/{movieId}?language={Language}");
    
    
    public async Task<CreditList?> GetMovieCreditsAsync(int movieId)
        => await GetMovieDetailAsync<CreditList>($"movie/{movieId}/credits?language={Language}");
    
    
}