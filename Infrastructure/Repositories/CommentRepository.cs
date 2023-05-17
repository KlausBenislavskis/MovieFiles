using LinqToDB;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using MovieFiles.Infrastructure.Mappers;

namespace MovieFiles.Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(string serverName, string databaseName, string userName, string password) : base(serverName, databaseName, userName, password)
        {
        }

        public async Task Comment(Comment comment, int movieId, Guid userId)
        {
            using var db = GetQuantityDbUserConnection();
            await db.InsertAsync(DomToDb.Map(comment, movieId, userId));
        }

        public async Task<List<Comment>> GetComments(int movieId, int page)
        {

            using var db = GetQuantityDbUserConnection();
            return (await db.MovieComments.Where(comment => comment.MovieId == movieId)
                .Skip((page-1) *20)
                .Take(20)
                .ToListAsync())
                .Select(DbToDom.Map)
                .ToList();
        }
    }
}
