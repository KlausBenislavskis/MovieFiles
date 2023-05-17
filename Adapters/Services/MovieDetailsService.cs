using System.Net.Http.Headers;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;

namespace MovieFiles.Adapters.Services;

public class MovieDetailsService : IMovieDetailsService
{
    private readonly HttpClient _httpClient;
    private const string language = "en-US";

    public MovieDetailsService(string apiToken)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer",apiToken );
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }


    public async Task<Movie> GetMovieDetailsAsync(int movieId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"movie/{movieId}?language={language}");
        if (!response.IsSuccessStatusCode)
        {
            return new Movie();
        }

        string jsonResponse = await response.Content.ReadAsStringAsync(); 
        Console.WriteLine(jsonResponse);
        Movie? movie = MovieApiUtil.ConvertApiMessage<Movie>(jsonResponse);
        
        return movie?? new Movie();
    }
}