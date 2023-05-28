using LinqToDB;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Interfaces.Statistics;
using MovieFiles.Core.Models;
using MovieFiles.Infrastructure.Mappers;

namespace MovieFiles.Infrastructure.Repositories;

public class StatisticsRepository : BaseRepository, IMovieStatisticsRepository
{

    public StatisticsRepository(string serverName, string databaseName, string userName, string password) : base(
        serverName, databaseName, userName, password)
    {
    }
    
    
    public async Task<Core.Models.MovieStatistics> GetAllStatisticsMovieListAsync(int movieId)
    {
        await using var db = GetQuantityDbUserConnection();

        var counts = new Dictionary<MyMovieListItem.ListType, int?>();

        foreach (MyMovieListItem.ListType listType in Enum.GetValues(typeof(MyMovieListItem.ListType)))
        {
            var count = await db.MovieLists
                .Where(m => m.ListName == MyMovieListItem.GetListTypeName(listType) && m.MovieId == movieId)
                .CountAsync();

            counts.Add(listType, count);
        }

        return DbToDom.Map(counts);
    }
    
    

    public async Task<int?> GetStatisticsWatchLaterMovieAsync(int movieId)
    {
        await using var db = GetQuantityDbUserConnection();

        var count = await db.MovieLists
            .Where(m => m.ListName == MyMovieListItem.GetListTypeName(MyMovieListItem.ListType.WATCH_LATER) &&
                        m.MovieId == movieId)
            .CountAsync();
        return count;
    }

    public async Task<int?> GetStatisticsAlreadyWatchedMovieAsync(int movieId)
    {
        await using var db = GetQuantityDbUserConnection();
        var count = await db.MovieLists
            .Where(m => m.ListName == MyMovieListItem.GetListTypeName(MyMovieListItem.ListType.ALREADY_WATCHED) &&
                        m.MovieId == movieId)
            .CountAsync();
        return count;
    }

    public async Task<int?> GetStatisticsFavoriteMovieAsync(int movieId)
    {
        await using var db = GetQuantityDbUserConnection();
        var count = await db.MovieLists
            .Where(m => m.ListName == MyMovieListItem.GetListTypeName(MyMovieListItem.ListType.TOPLIST) &&
                        m.MovieId == movieId)
            .CountAsync();
        return count;
    }
}