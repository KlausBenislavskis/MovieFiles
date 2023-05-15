using Microsoft.AspNetCore.Mvc;
using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IMoviesService
    {
        Task<(IList<Movie>?, HttpResponseMessage?)> GetLatestMoviesAsync(String apiKey);
        Task<(IList<Movie>?, HttpResponseMessage?)> GetNowPlayingMoviesAsync(String apiKey);
        Task<(IList<Movie>?, HttpResponseMessage?)> GetPopularMoviesAsync(String apiKey);
        Task<(IList<Movie>?, HttpResponseMessage?)> GetTopRatedMoviesAsync(String apiKey);
        Task<(IList<Movie>?, HttpResponseMessage?)> GetUpcomingMoviesAsync(String apiKey);
    }

}