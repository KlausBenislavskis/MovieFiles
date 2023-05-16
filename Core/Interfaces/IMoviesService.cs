using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IMoviesService
    {
        Task<MovieList> GetNowPlayingMoviesAsync(int page);
        Task<MovieList> GetPopularMoviesAsync(int page);
        Task<MovieList> GetTopRatedMoviesAsync(int page);
        Task<MovieList> GetUpcomingMoviesAsync(int page);

        /// <summary>
        /// method to acquire movies based on search name (search is infix)
        /// </summary>
        /// <param name="name">searched term</param>
        /// <param name="page">number of page that you want to get results of</param>
        /// <returns> list of movies including information about page and number of results</returns>
        Task<MovieList> SearchForMovies(string name, int page);
    }

}