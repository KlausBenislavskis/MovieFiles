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
                MovieId = (int) rating.MovieId,
                UserId = (Guid) rating.UserId,
                RatingValue = (int) rating.RatingValue
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
                Adult = movie.Adult,
                Overview = movie.Overview,
                ReleaseDate = movie.ReleaseDate,
                GenreIds = movie.GenreIds,
                Id = (int)movie.Id,
                OriginalTitle = movie.OriginalTitle,
                OriginalLanguage = movie.OriginalLanguage,
                Title = movie.Title,
                BackdropPath = movie.BackdropPath,
                Popularity = movie.Popularity,
                VoteCount = movie.VoteCount,
                Video = movie.Video,
                VoteAverage = movie.VoteAverage
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