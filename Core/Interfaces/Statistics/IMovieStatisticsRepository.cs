using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces.Statistics;

public interface IMovieStatisticsRepository
{
    Task<Core.Models.MovieStatistics> GetAllStatisticsMovieListAsync(int movieId);
    Task<int?> GetStatisticsWatchLaterMovieAsync(int movieId);
    Task<int?> GetStatisticsFavoriteMovieAsync(int movieId);
    Task<int?> GetStatisticsAlreadyWatchedMovieAsync(int movieId);
}