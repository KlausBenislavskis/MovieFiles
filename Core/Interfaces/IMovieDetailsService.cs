using Microsoft.AspNetCore.Mvc;
namespace MovieFiles.Core.Interfaces
{
    public interface IMovieDetailsService
    {
        Task<IActionResult> GetLatestMoviesAsync(String apiKey);
        Task<IActionResult> GetNowPlayingMoviesAsync(String apiKey);
        Task<IActionResult> GetPopularMoviesAsync(String apiKey);
        Task<IActionResult> GetTopRatedMoviesAsync(String apiKey);
        Task<IActionResult> GetUpcomingMoviesAsync(String apiKey);
    }

}