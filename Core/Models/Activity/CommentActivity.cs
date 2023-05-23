namespace MovieFiles.Core.Models.Activity
{
    public class CommentActivity : BaseActivity
    {
        public CommentActivity() : base(ActivityType.COMMENTED)
        {
        }

        public string CommentText { get; set; }

    }
}
