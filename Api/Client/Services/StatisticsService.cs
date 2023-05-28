using MovieFiles.Api.Client.Mappers;
using MovieFiles.Core.Interfaces.Statistics;

namespace MovieFiles.Api.Client.Services;

public class StatisticsService : BaseService, IMovieStatisticsService
{
    public StatisticsService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
    {
    }

    public async Task<Core.Models.MovieStatistics> GetAllStatisticsMovieListAsync(int movieId)
    {
        var response = await _client.GetMovieStatisticsAsync(movieId, _functionAppKey);
        return ClientToUi.Map(response);
    }

    public async Task<int?> GetStatisticsWatchLaterMovieAsync(int movieId)
    {
        return await _client.GetMovieWatchLaterStatisticsAsync(movieId, _functionAppKey);
    }

    public async Task<int?> GetStatisticsFavoriteMovieAsync(int movieId)
    {
        return await _client.GetMovieTopListStatisticsAsync(movieId, _functionAppKey);
    }

    public async Task<int?> GetStatisticsAlreadyWatchedMovieAsync(int movieId)
    {
        return await _client.GetMovieAlreadyWatchedStatisticsAsync(movieId, _functionAppKey);
    }
}