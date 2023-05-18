using MovieFiles.Api.Client.Mappers;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;

namespace MovieFiles.Api.Client.Services;

public class MovieDetailsService : IMovieDetailsService
{
    private readonly MovieFilesFunctions _client;
    private readonly string _functionAppKey;

    public MovieDetailsService(string httpUrl, string functionAppKey)
    {
        _client = new MovieFilesFunctions(new HttpClient { BaseAddress = new Uri(httpUrl) });
        _client.BaseUrl = httpUrl;
        _functionAppKey = functionAppKey;
    }

    public async Task<Core.Models.Movie?> GetMovieDetailsAsync(int movieId)
    {
        var response = await _client.GetMovieDetailsAsync(movieId, _functionAppKey);
        return ClientToUi.Map(response);
    }

    public Task<Core.Models.CreditList?> GetMovieCreditsAsync(int movieId)
    {
        throw new NotImplementedException();
    }
}