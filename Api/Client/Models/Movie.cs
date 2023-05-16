namespace MovieFiles.Api.Client.Models;

public class Movie
{
    
    public string? PosterPath { get; set; }
    public bool? Adult { get; set; }
    public string Overview { get; set; }
    public string ReleaseDate { get; set; }
    public ICollection<int> GenreIds { get; set; }
    public int Id { get; set; }
    public string OriginalTitle { get; set; }
    public string OriginalLanguage { set; get; }
    public string Title { set; get; }
    public string? BackdropPath { set; get; }
    public double? Popularity { set; get; }
    public int? VoteCount { set; get; }
    public bool? Video { get; set; }
    public double? VoteAverage { get; set; }
}