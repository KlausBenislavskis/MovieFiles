using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingAsync(Guid userId, int movieId);
        Task SetRatingAsync(Rating rating);
        Task<IEnumerable<Rating>> GetRatingsByUserAsync(Guid userId);
        Task<IEnumerable<Rating>> GetRatingsForMovieAsync(int movieId);
        Task<double?> GetAverageRatingForMovieAsync(int movieId);
    }

}
