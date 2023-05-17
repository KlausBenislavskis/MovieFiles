namespace MovieFiles.Api.Client.Models;

public class MovieList
{
    public MovieList(int loadingItems =  0)
    {
        Results = new List<Movie>();
        for (int i = 0; i < loadingItems; i++)
        {
            Results.Add(new Movie());
        }
    }
    public int? Page {get;set;}
    public List<Movie> Results {get;set;}
    public int? TotalPages {get;set;}
}