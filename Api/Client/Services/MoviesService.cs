using MovieFiles.Api.Client.Mappers;
using MovieFiles.Api.Client.Services.Interfaces;

namespace MovieFiles.Api.Client.Services;

public class MoviesService : BaseService, IMoviesService
{
    public MoviesService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
    {
    }
    
    public async Task<Models.MovieList> GetPopularMoviesAsync(int page)
    {
        var response = await _client.GetPopularMoviesAsync(page, _functionAppKey);
        return ClientToUi.Map(response);
    }

    public async Task<Models.MovieList> GetNowPlayingMoviesAsync(int page)
    {
        var response = await _client.GetNowPlayingMoviesAsync(page, _functionAppKey);
        return ClientToUi.Map(response);
    }

    public async Task<Models.MovieList> GetTopRatedMoviesAsync(int page)
    {
        var response = await _client.GetTopRatedMoviesAsync(page, _functionAppKey);
        return ClientToUi.Map(response);
    }

    public async Task<Models.MovieList> GetUpcomingMoviesAsync(int page)
    {
        var response = await _client.GetUpcomingMoviesAsync(page, _functionAppKey);
        return ClientToUi.Map(response);
    }
}