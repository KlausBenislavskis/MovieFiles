using System.Text.Json.Serialization;

namespace MovieFiles.Core.Models
{
    /// <summary>
    /// Class that represents what attributes a movie have and which of them can be nullable from API
    /// </summary>
    public class Movie
    {
        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("genre_ids")]
        public int[] GenreIds { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }
        [JsonPropertyName("original_language")]
        public string OriginalLanguage { set; get; }
        [JsonPropertyName("title")]
        public string Title { set; get; }
        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { set; get; }
        [JsonPropertyName("popularity")]
        public float Popularity { set; get; }
        [JsonPropertyName("vote_count")]
        public int VoteCount { set; get; }
        [JsonPropertyName("video")]
        public bool Video { get; set; }
        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; set; }
    }
}