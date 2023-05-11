using LinqToDB;
using MovieFiles.Core.Interfaces;
using MovieFiles.Infrastructure.Mappers;

namespace MovieFiles.Infrastructure.Repositories
{
    public class RatingRepository : BaseRepository, IRatingRepository
    {
        public RatingRepository(string serverName, string databaseName, string userName, string password) : base(serverName, databaseName, userName, password)
        {
        }

        public async Task<Core.Models.Rating> GetRatingAsync(Guid userId, Guid movieId)
        {
            using var db = GetQuantityDbUserConnection();
            var dbRating = await db.Ratings.FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == movieId);
            return dbRating != null ? DbToDom.Map(dbRating) : null;
        }

        public async Task UpdateRatingAsync(Core.Models.Rating rating)
        {
            using var db = GetQuantityDbUserConnection();
            await db.Ratings.Where(r => r.UserId == rating.UserId && r.MovieId == rating.MovieId).Set(r => r.Rating1, rating.RatingValue).UpdateAsync();
        }

        public async Task DeleteRatingAsync(Guid userId, Guid movieId)
        {
            using var db = GetQuantityDbUserConnection();
            await db.Ratings.Where(r => r.UserId == userId && r.MovieId == movieId)?.DeleteAsync();
        }

        public async Task AddRatingAsync(Core.Models.Rating rating)
        {
            using (var db = GetQuantityDbUserConnection())
            {
                var dbRating = DomToDb.Map(rating);
                await db.InsertAsync(dbRating);
            }
        }

        public async Task<IEnumerable<Core.Models.Rating>> GetRatingsByUserAsync(Guid userId)
        {
            using var db = GetQuantityDbUserConnection();
            var dbRatings = await db.Ratings.Where(r => r.UserId == userId).ToListAsync();
            return dbRatings.Select(DbToDom.Map);
        }

        public async Task<IEnumerable<Core.Models.Rating>> GetRatingsForMovieAsync(Guid movieId)
        {
            using var db = GetQuantityDbUserConnection();
            var dbRatings = await db.Ratings.Where(r => r.MovieId == movieId).ToListAsync();
            return dbRatings.Select(DbToDom.Map);
        }
    }
}
