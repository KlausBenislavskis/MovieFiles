namespace MovieFiles.Api.Client.Mappers
{
    internal class UiToClient
    {
        internal static Rating Map(Core.Models.Rating rating)
        {
            return new()
            {
                MovieId = rating.MovieId,
                UserId = rating.UserId,
                RatingValue = rating.RatingValue
            };
        }

        internal static Comment Map(Core.Models.Comment comment)
        {
            return new()
            {
                Author = comment.Author,
                Text = comment.Text,
            };
        }
    }
}
