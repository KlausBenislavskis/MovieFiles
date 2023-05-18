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

            try { 

            await db.InsertAsync(mappedActivity);
            }
            catch (Exception ex)
            {

            }
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

        public Task<List<BaseActivity>> GetActivities(Guid userId)
        {



            throw new NotImplementedException();
        }
    }
}
