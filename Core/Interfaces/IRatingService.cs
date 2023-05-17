using MovieFiles.Core.Models;

namespace MovieFiles.Api.Client.Services
{
    public interface IRatingService
    {
        Task<Rating?> GetRatingAsync(Guid userId, int movieId);
        Task<double?> GetAverageRating(int movieId);
        Task SetRatingAsync(Rating rating);
        Task<IEnumerable<Rating>> GetRatingsByUserAsync(Guid userId);
        Task<IEnumerable<Rating>> GetRatingsForMovieAsync(int movieId);
    }
}
