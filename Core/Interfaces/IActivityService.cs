using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IActivityService
    {
        public Task<List<BaseActivity>> GetActivities(Guid userId, int page = 1, int pageSize = 25);
    }
}
