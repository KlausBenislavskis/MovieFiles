namespace MovieFiles.Api.Client.Services
{
    public interface IRatingService
    {
        Task<Models.Rating?> GetRatingAsync(Guid userId, Guid movieId);
        Task<double?> GetAverageRating(Guid movieId);
        Task SetRatingAsync(Models.Rating rating);
        Task<IEnumerable<Models.Rating>> GetRatingsByUserAsync(Guid userId);
        Task<IEnumerable<Models.Rating>> GetRatingsForMovieAsync(Guid movieId);
    }
}
