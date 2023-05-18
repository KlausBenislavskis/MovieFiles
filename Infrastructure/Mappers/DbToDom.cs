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

        internal static Core.Models.User Map(Scaffold.User dbRating)
        {
            return new User()
            {
                Id = dbRating.UserId,
                Username = dbRating.UserName
            };
        }
    }
}
