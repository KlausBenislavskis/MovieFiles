using MovieFiles.Core.Models.Activity;
using MovieFiles.Core.Models;

namespace MovieFiles.Infrastructure.Mappers
{
    internal class DbToDom
    {
        internal static Core.Models.Rating Map(Scaffold.Rating dbRating)
        {
            return new()
            {
                UserId = dbRating.UserId,
                MovieId = dbRating.MovieId,
                RatingValue = dbRating.Rating1
            };
        }
        internal static Core.Models.Comment Map(Scaffold.MovieComment comment)
        {
            return new()
            {
                Author = comment.UserName,
                Text = comment.Comment
            };
        }
        internal static BaseActivity Map(Scaffold.UserActivity scaffoldActivity)
        {
            BaseActivity activity;

            switch (scaffoldActivity.ActivityType)
            {
                case "RATED":
                    activity = MapToRatingActivity(scaffoldActivity);
                    break;
                // case "OTHER":
                //     activity = MapToOtherActivity(scaffoldActivity);
                //     break;
                default:
                    throw new NotImplementedException("Need to create mapping for this activity");
            }

            // Assuming BaseActivity has these properties
            activity.MovieId = (int)scaffoldActivity.MovieId;
            activity.Created = (DateTime)scaffoldActivity.Timestamp;
            activity.Username = scaffoldActivity.UserName;
            //activity.UserId = (Guid)scaffoldActivity.UserId;
            return activity;
        }

        private static RatingActivity MapToRatingActivity(Scaffold.UserActivity scaffoldActivity)
        {
            return new RatingActivity
            {
                RatingValue = (int)scaffoldActivity.RatingValue,
                // set other specific properties of RatingActivity here
            };
        }

        internal static Core.Models.MyMovieListItem Map(Scaffold.MovieList dbMovie){
            return new()
            {
                UserId = dbMovie.UserId,
                MovieId = dbMovie.MovieId,
                ListId = dbMovie.ListId,
                ListName = dbMovie.ListName
            };
        }
    }
}
