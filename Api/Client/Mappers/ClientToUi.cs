using MovieFiles.Core.Models;

namespace MovieFiles.Api.Client.Mappers
{
    internal class ClientToUi
    {
        internal static Core.Models.Rating Map(Rating rating)
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

        internal static Core.Models.Movie? Map(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            return new()
            {
                Id = (int)movie.Id,
                ImdbId = movie.ImdbId,
                PosterPath = movie.PosterPath,
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle,
                ReleaseDate = movie.ReleaseDate,
                Revenue = (double)movie.Revenue,
                Budget = (double)movie.Budget,
                Overview = movie.Overview,
                Runtime = (int)movie.Runtime,
            };
        }

        internal static Core.Models.MovieList Map(MovieList movieList)
        {
            if (movieList == null)
            {
                return null;
            }

            return new()
            {
                Page = (int)movieList.Page,
                Results = movieList.Results.Select(Map).ToArray(),
                TotalPages = (int)movieList.TotalPages
            };
        }
        
        internal static Core.Models.CreditList Map(CreditList creditList)
        {
            if (creditList == null)
            {
                return null;
            }

            return new()
            {
                
               // Results = creditList.Results.Select(Map).ToArray()
           
            };
        }
    }
}