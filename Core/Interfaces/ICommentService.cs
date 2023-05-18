using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments(int movieId, int page);
        Task Comment(Comment comment, int movieId, Guid userId);
    }
}
