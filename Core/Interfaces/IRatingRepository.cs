using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingAsync(Guid userId, Guid movieId);
        Task AddRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(Guid userId, Guid movieId);
        Task<IEnumerable<Rating>> GetRatingsByUserAsync(Guid userId);
        Task<IEnumerable<Rating>> GetRatingsForMovieAsync(Guid movieId);
    }

}
