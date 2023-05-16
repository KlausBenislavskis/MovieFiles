

namespace MovieFiles.Api.Client.Services.Interfaces;

public interface IMoviesService
{
    Task<Models.MovieList> GetPopularMoviesAsync(int page);
    
    Task<Models.MovieList> GetNowPlayingMoviesAsync(int page);
    
    Task<Models.MovieList> GetTopRatedMoviesAsync(int page);
    Task<Models.MovieList> GetUpcomingMoviesAsync(int page);
}