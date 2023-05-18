using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using MovieFiles.Infrastructure.Mappers;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;

namespace MovieFiles.Infrastructure.Repositories
{
    public class MovieListRepository : BaseRepository, IMovieListService
    {
        public static readonly int PAGE_SIZE = 20;
        public MovieListRepository(string serverName, string databaseName, string userName, string password) : base(serverName, databaseName, userName, password){}

        public async Task<bool> AddMovieToWatchLater(int movieId, Guid userId){
            using var db = GetQuantityDbUserConnection();
            // first check if such movie is already on the list
            // as we use listID as identifier that can not be inserted we have to do it manually
            var countAlreadyExisting = await db.MovieLists.Where(ml =>
                ml.UserId == userId &&
                ml.MovieId == movieId &&
                ml.ListName == WatchLaterMovie.WATCH_LATER_LIST_NAME).CountAsync();
            if (countAlreadyExisting > 0){
                return false;
            }

            WatchLaterMovie movieList = new() {
                MovieId = movieId,
                UserId = userId
            };
            var dbMovieList = DomToDb.Map(movieList);
            var countEffectedRecords = await db.InsertAsync(dbMovieList);
            return countEffectedRecords>0;
        }

        public async Task<CustomMovieList<WatchLaterMovie>> GetWatchLaterList(Guid userId, int page){
            using var db = GetQuantityDbUserConnection();
            var dbMovieQuery = db.MovieLists.Where(ml => 
                    ml.UserId == userId && 
                    ml.ListName == WatchLaterMovie.WATCH_LATER_LIST_NAME);
            var totalResults = await dbMovieQuery.CountAsync();
            var dbMovies = await dbMovieQuery
                .Skip((page-1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToListAsync();

            var movies = dbMovies.Select(DbToDom.Map).ToArray();

            return new CustomMovieList<WatchLaterMovie>()
            {
                Page = page, 
                List = movies, 
                TotalResults = totalResults, 
                TotalPages = CalculateTotalPages(totalResults,PAGE_SIZE)
            };
        }

        public async Task<bool> RemoveMovieToWatchLater(int movieId, Guid userId)
        {
            using var db = GetQuantityDbUserConnection();
            var entryToRemove = db.MovieLists.Where(ml => 
                ml.UserId == userId &&
                ml.ListName == WatchLaterMovie.WATCH_LATER_LIST_NAME && 
                ml.MovieId == movieId);
            var entriesRemoved = await entryToRemove.DeleteAsync();
            return entriesRemoved>0;
        }

        private int CalculateTotalPages(int totalResults, int pageSize){
            return (int) Math.Ceiling((decimal) totalResults / pageSize);
        }
    }
}