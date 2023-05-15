namespace MovieFiles.Api.Client.Mappers
{
    internal class ClientToUi
    {
        internal static Models.Rating Map(Rating rating)
        {
            if (rating == null)
            {
                return null;
            }
            return new()
            {
                MovieId = (int)rating.MovieId,
                UserId = (Guid)rating.UserId,
                RatingValue = (int)rating.RatingValue
            };
        }
    }
}
