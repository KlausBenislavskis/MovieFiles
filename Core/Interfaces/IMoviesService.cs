using Microsoft.AspNetCore.Mvc;
using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IMoviesService
    {
        Task<(IList<Movie>?, HttpResponseMessage?)> GetLatestMoviesAsync();
        Task<(IList<Movie>?, HttpResponseMessage?)> GetNowPlayingMoviesAsync();
        Task<(IList<Movie>?, HttpResponseMessage?)> GetPopularMoviesAsync();
        Task<(IList<Movie>?, HttpResponseMessage?)> GetTopRatedMoviesAsync();
        Task<(IList<Movie>?, HttpResponseMessage?)> GetUpcomingMoviesAsync();
    }

}