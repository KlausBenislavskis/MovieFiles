using System.Diagnostics;

namespace MovieFiles.Core.Models
{
    public enum ActivityType
    {
        COMMENTED,
        FOLLOWED,
        RATED,
    }
    public abstract class BaseActivity
    {
        protected BaseActivity(ActivityType type)
        {
            Type = type;
        }

        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public int MovieId { get; set; }
        public ActivityType Type { get; set; }

    }
}
