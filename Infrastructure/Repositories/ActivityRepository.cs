using LinqToDB;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using MovieFiles.Infrastructure.Mappers;
using MovieFiles.Infrastructure.Scaffold;

namespace MovieFiles.Infrastructure.Repositories
{
    public class ActivityRepository : BaseRepository, IActivityRepository
    {
        public ActivityRepository(string serverName, string databaseName, string userName, string password) : base(serverName, databaseName, userName, password)
        {
        }

        public async Task AddActivity(BaseActivity baseActivity)
        {
            using var db = GetQuantityDbUserConnection();
            var mappedActivity = DomToDb.Map(baseActivity);
            
            await CheckIfRatingActivityExistsAlready(mappedActivity, db);

            await db.InsertAsync(mappedActivity);
        }

        private async Task CheckIfRatingActivityExistsAlready(Activity mappedActivity, MovieFilesDb db)
        {
            if(mappedActivity.ActivityType != ActivityType.RATED.ToString())
            {
                return;
            }
            await db.Activities.DeleteAsync(activity => activity.MovieId == mappedActivity.MovieId && 
            activity.UserId == mappedActivity.UserId);
        }

        public async Task<List<BaseActivity>> GetActivities(Guid userId, int page = 1, int pageSize = 25)
        {
            using var db = GetQuantityDbUserConnection();

            return (await db.UserActivities.Where(x => x.UserId == userId)
                .Skip((page - 1)* pageSize)
                .Take(pageSize)
                .ToListAsync())
                .Select(DbToDom.Map)
                .ToList();
        }
    }
}
