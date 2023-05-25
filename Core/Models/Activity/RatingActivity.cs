namespace MovieFiles.Core.Models.Activity
{
    public class RatingActivity : BaseActivity
    {
        public RatingActivity() : base(ActivityType.RATED)
        {
        }

        public int RatingValue { get; set; }

    }
}
