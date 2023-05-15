namespace MovieFiles.Api.Client.Models;

public class MovieList
{
    public int? Page {get;set;}
    public List<Movie> Results {get;set;}
    public int? TotalPages {get;set;}
}