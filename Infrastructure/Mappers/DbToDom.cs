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
    }
}
