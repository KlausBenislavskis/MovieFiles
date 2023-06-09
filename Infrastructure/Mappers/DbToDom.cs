﻿using MovieFiles.Core.Models.Activity;
using MovieFiles.Core.Models;
using MovieFiles.Infrastructure.Scaffold;

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
                case "COMMENTED":
                    activity = MapToCommentActivity(scaffoldActivity);
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

        private static CommentActivity MapToCommentActivity(UserActivity scaffoldActivity)
        {
            return new CommentActivity
            {
                CommentText = scaffoldActivity.CommentText,
                // set other specific properties of CommentActivity here
            };
        }

        private static RatingActivity MapToRatingActivity(Scaffold.UserActivity scaffoldActivity)
        {
            return new RatingActivity
            {
                RatingValue = (int)scaffoldActivity.RatingValue,
                // set other specific properties of RatingActivity here
            };
        }

        internal static Core.Models.User Map(Scaffold.User dbUser)
        {
            return new ()
            {
                Id = dbUser.UserId,
                Username = dbUser.UserName
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
        internal static MovieStatistics Map(Dictionary<MyMovieListItem.ListType, int?> counts)
        {
            return new MovieStatistics
            {
                WatchLaterCount = counts.TryGetValue(MyMovieListItem.ListType.WATCH_LATER, out var watchLaterCount)
                    ? watchLaterCount
                    : null,
                AlreadyWatchedCount = counts.TryGetValue(MyMovieListItem.ListType.ALREADY_WATCHED, out var alreadyWatchedCount)
                    ? alreadyWatchedCount
                    : null,
                FavoriteCount = counts.TryGetValue(MyMovieListItem.ListType.TOPLIST, out var favoriteCount)
                    ? favoriteCount
                    : null
            };
        }
    }
}
