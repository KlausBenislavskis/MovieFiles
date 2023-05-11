using MovieFiles.Core.Models;
namespace MovieFiles.Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<IActionResult> GetTopRatedMoviesAsync();
        Task<IActionResult> GetLatestMoviesAsync();
        Task<IActionResult> GetUpcomingMoviesAsync();
        Task<IActionResult> GetPopularMoviesAsync();
    }

}