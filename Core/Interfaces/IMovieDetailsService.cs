using Microsoft.AspNetCore.Mvc;
using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IMovieDetailsService
    {
        Task<Movie?> GetMovieDetailsAsync(int movieId);

        Task<CreditList?> GetMovieCreditsAsync(int movieId); 
    }

}