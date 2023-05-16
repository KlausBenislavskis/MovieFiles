namespace MovieFiles.Core.Models
{
    public class MovieList
    {
        //Default Constructor
        public MovieList()
        {
            Page = 0;
            Results = new Movie[0];
            TotalPages = 0;
            TotalResults = 0;
        }

        public int Page { get; set; }
        public Movie[] Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
    }
}