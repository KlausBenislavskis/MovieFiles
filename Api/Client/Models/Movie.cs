namespace MovieFiles.Api.Client.Models;

public class Movie
{
        public int Id { get; set; }

        public int ImdbId { get; set; }

        public string PosterPath { get; set; }

        public string Title { get; set; }

        public string OriginalTitle { get; set; }

        public string ReleaseDate { get; set; }

        public double Revenue { get; set; }

        public double Budget { get; set; }

        public string Overview { get; set; }

        public int Runtime { get; set; }

        //public ICollection<Genre> Genres { get; set; }

        //public ICollection<ProductionCompany> ProductionCompanies { get; set; }
}