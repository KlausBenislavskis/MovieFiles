using System.Text.Json.Serialization;

namespace MovieFiles.Core.Models
{
    /// <summary>
    /// Class that represents what attributes a movie have and which of them can be nullable from API
    /// </summary>
    public class Movie
    {
        public string? PosterPath { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public int[] GenreIds { get; set; }
        public int Id { get; set; }
        public string OriginalTitle { get; set; }
        public string OriginalLanguage { set; get; }
        public string Title { set; get; }
        public string? BackdropPath { set; get; }
        public float Popularity { set; get; }
        public int VoteCount { set; get; }
        public bool Video { get; set; }
        public float VoteAverage { get; set; }
    }
}