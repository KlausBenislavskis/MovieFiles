namespace MovieFiles.Api.Client.Models;

public class MovieList
{
    public MovieList()
    {
        Results = new List<Movie>();
    }
    public int? Page {get;set;}
    public List<Movie> Results {get;set;}
    public int? TotalPages {get;set;}
}