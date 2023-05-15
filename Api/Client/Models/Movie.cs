namespace MovieFiles.Api.Client.Models;

public class Movie
{
    public string? PosterPath { get; set; }
    public string OriginalTitle { get; set; }
    public string Title { set; get; }
    public float VoteAverage { get; set; } // might be needed to remove
}