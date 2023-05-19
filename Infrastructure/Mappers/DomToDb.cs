using MovieFiles.Core.Models;

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
