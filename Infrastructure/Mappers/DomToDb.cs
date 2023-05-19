﻿using MovieFiles.Core.Models;
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
