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
                MovieId = (int)rating.MovieId,
                UserId = (Guid)rating.UserId,
                RatingValue = (int)rating.RatingValue
            };
        }

        internal static Core.Models.Movie Map(Movie movie)
        {
            if (movie == null)
            {
                return new ();
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
                Genres = movie.Genres?.Select(x => Map(x))?.ToList(),
                ProductionCompanies = movie.ProductionCompanies?.Select(x => Map(x))?.ToList()
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

        internal static Core.Models.Crew Map(Crew crew)
        {
            if (crew == null)
            {
                return null;
            }
        
            return new()
            {
                Adult = (bool)crew.Adult,
                Gender = (int)crew.Gender,
                Id = (int)crew.Id,
                KnownForDepartment = crew.KnownForDepartment,
                Name = crew.Name,
                OriginalName = crew.OriginalName,
                Popularity = (double)crew.Popularity,
                ProfilePath = crew.ProfilePath,
                CreditId = crew.CreditId,
                Department = crew.Department,
                Job = crew.Job
            };
        }
        
        internal static Core.Models.Cast Map(Cast cast)
        {
            if (cast == null)
            {
                return null;
            }
        
            return new()
            {
                Adult = (bool)cast.Adult,
                Gender = (int)cast.Gender,
                Id = (int)cast.Id,
                KnownForDepartment = cast.KnownForDepartment,
                Name = cast.Name,
                OriginalName = cast.OriginalName,
                Popularity = (double)cast.Popularity,
                ProfilePath = cast.ProfilePath,
                CastId = (int)cast.CastId,
                Character = cast.Character,
                CreditId = cast.CreditId,
                Order = (int)cast.Order
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
                 Cast = creditList.Cast.Select(Map).ToArray(),
                 Crew = creditList.Crew.Select(Map).ToArray()
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
        
        internal static Core.Models.ProductionCompany Map(ProductionCompany productionCompany)
        {
            if (productionCompany == null)
            {
                return new();
            }

            return new()
            {
                Id = (int)productionCompany.Id,
                Name = productionCompany.Name,
                LogoPath = productionCompany.LogoPath,
                OriginCountry = productionCompany.OriginCountry
            };
        }
                
        internal static Core.Models.GenreList Map(GenreList genreList)
        {
            if (genreList == null)
            {
                return new();
            }

            return new()
            {
                Genres = genreList.Genres.Select(Map).ToList()
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

        internal static Core.Models.Genre Map(Genre genre){
            if (genre == null){
                return null;
            }
            return new() {
                Id = (int)genre.Id,
                Name = genre.Name
            };
        }

        // internal static Core.Models.GenreList Map(GenreList genreList){
        //     if (genreList == null){
        //         return null;
        //     }
        //     return new(){
        //         Genres = genreList.Genres.Select(Map).ToList()
        //     };
        // }

        internal static Core.Models.People.Person Map(Person person){
            return new(){
                Id = (int)person.Id,
                Name = person.Name
            };
        }

        internal static Core.Models.People.PeopleList Map(PeopleList list){
            return new() {
                Page = (int)list.Page,
                Results = list.Results.Select(Map).ToList(),
                TotalPages = (int)list.TotalPages,
                TotalResults = (int)list.TotalResults
            };
        }

        internal static List<string> Map(ICollection<string> listNames){
            return new(listNames);
        }
    }
}