namespace MovieFiles.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string PosterPath { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string ReleaseDate { get; set; }
        public double Revenue { get; set; }
        public double Budget { get; set; }
        public string Overview { get; set; }
        public int Runtime { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<ProductionCompany> ProductionCompanies { get; set; }
    }
}
