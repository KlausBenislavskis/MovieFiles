using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingAsync(Guid userId, Guid movieId);
        Task SetRatingAsync(Rating rating);
        Task<IEnumerable<Rating>> GetRatingsByUserAsync(Guid userId);
        Task<IEnumerable<Rating>> GetRatingsForMovieAsync(Guid movieId);
        Task<double?> GetAverageRatingForMovieAsync(Guid movieId);
    }

}
