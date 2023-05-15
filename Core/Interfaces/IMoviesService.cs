using MovieFiles.Core.Models;
namespace MovieFiles.Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<IActionResult> GetLatestMoviesAsync();
        Task<IActionResult> GetNowPlayingMoviesAsync();
        Task<IActionResult> GetPopularMoviesAsync();
        Task<IActionResult> GetTopRatedMoviesAsync();
        Task<IActionResult> GetUpcomingMoviesAsync();
    }

}