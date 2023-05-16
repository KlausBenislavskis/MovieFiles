namespace MovieFiles.Api.Client.Services
{
    public interface IRatingService
    {
        Task<Models.Rating?> GetRatingAsync(Guid userId, int movieId);
        Task<double?> GetAverageRating(int movieId);
        Task SetRatingAsync(Models.Rating rating);
        Task<IEnumerable<Models.Rating>> GetRatingsByUserAsync(Guid userId);
        Task<IEnumerable<Models.Rating>> GetRatingsForMovieAsync(int movieId);
    }
}
