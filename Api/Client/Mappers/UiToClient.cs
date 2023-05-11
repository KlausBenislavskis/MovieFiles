namespace MovieFiles.Api.Client.Mappers
{
    internal class UiToClient
    {
        internal static Rating Map(Models.Rating rating)
        {
            return new ()
            {
                MovieId = rating.MovieId,
                UserId = rating.UserId,
                RatingValue = rating.RatingValue
            };
        }
    }
}
