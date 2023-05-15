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
        internal static Models.Movie Map(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }
            return new()
            {
                PosterPath = movie.PosterPath,
            };
        }
        internal static Models.MovieList Map(MovieList movieList)
        {
            if (movieList == null)
            {
                return null;
            }
            return new()
            {
                Page = movieList.Page,
                Results = movieList.Results.Select(Map).ToList(),
                TotalPages = movieList.TotalPages
            };
        }
    }
}
