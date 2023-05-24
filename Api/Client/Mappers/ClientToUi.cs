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
                MovieId = (int)rating.MovieId,
                UserId = (Guid)rating.UserId,
                RatingValue = (int)rating.RatingValue
            };
        }

        internal static Core.Models.Movie Map(Movie movie)
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

        internal static Core.Models.Credit Map(Credit credit)
        {
            if (credit == null)
            {
                return null;
            }

            return new()
            {
                Adult = (bool)credit.Adult,
                Gender = (int)credit.Gender,
                Id = (int)credit.Id,
                KnownForDepartment = credit.KnownForDepartment,
                Name = credit.Name,
                OriginalName = credit.OriginalName,
                Popularity = (double)credit.Popularity,
                ProfilePath = credit.ProfilePath,
                CastId = (int)credit.CastId,
                Character = credit.Character,
                CreditId = credit.CreditId,
                Order = (int)credit.Order
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
                Cast = creditList.Cast.Select(Map).ToArray()
            };
        }

        internal static Core.Models.Comment Map(Comment comment)
        {
            if (comment == null)
            {
                return new();
            }

            return new()
            {
                Author = comment.Author,
                Text = comment.Text
            };
        }
        internal static Core.Models.User Map(User user)
        {
            if (user == null)
            {
                return new();
            }

            return new()
            {
                Id = (Guid)user.Id,
                Username = user.Username
            };
        }
    }
}