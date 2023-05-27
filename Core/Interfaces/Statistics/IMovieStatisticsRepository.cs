namespace MovieFiles.Core.Interfaces;

public interface IMovieStatisticsRepository
{
    Task<int?> GetStatisticsWatchLaterMovieAsync(int movieId);
    Task<int?> GetStatisticsAlreadyWatchedMovieAsync(int movieId);
    Task<int?> GetStatisticsFavoriteMovieAsync(int movieId);
}