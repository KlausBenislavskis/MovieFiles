using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MovieFiles.Core.Models;
using MovieFiles.Core.Models.Activity;
using System.Linq.Expressions;

namespace MovieFiles.Infrastructure.Mappers
{
    internal class DomToDb
    {
        internal static Scaffold.Rating Map(Rating rating)
        {
            return new()
            {
                UserId = rating.UserId,
                MovieId = rating.MovieId,
                Rating1 = rating.RatingValue
            };
        }

        internal static Scaffold.Comment Map(Comment comment, int movieId, Guid userId)
        {
            return new()
            {
                UserId = userId,
                Comment1 = comment.Text,
                MovieId = movieId
            };


        }

        internal static Scaffold.Activity Map(BaseActivity baseActivity)
        {
            Scaffold.Activity activity;

            switch (baseActivity)
            {
                case RatingActivity ratingActivity:
                    activity = Map(ratingActivity);
                    break;
                case CommentActivity commentActivity:
                    activity = Map(commentActivity);
                    break;
                default:
                    throw new NotImplementedException("Need to create mapping for this activity");
            }

            activity.MovieId = baseActivity.MovieId;
            activity.Timestamp = baseActivity.Created;
            activity.UserId = baseActivity.UserId;
            activity.ActivityType = baseActivity.Type.ToString();

            return activity;
        }

        internal static Scaffold.Activity Map(RatingActivity ratingActivity)
        {
            return new Scaffold.Activity
            {
                RatingValue = ratingActivity.RatingValue,
            };
        }
        internal static Scaffold.Activity Map(CommentActivity ratingActivity)
        {
            return new Scaffold.Activity
            {
                CommentText = ratingActivity.CommentText,
            };
        }
        internal static Scaffold.MovieList Map(MyMovieListItem movie){
            return new()
            {
                UserId = movie.UserId,
                MovieId = movie.MovieId,
                ListName = movie.ListName
            };
        }
    }
}
