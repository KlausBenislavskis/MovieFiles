using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MovieFiles.Core.Models
{
    public class MovieList
    {
        [JsonPropertyName("page")]
        public int page {get;set;}
        [JsonPropertyName("results")]
        public Movie[] Results {get;set;}
        [JsonPropertyName("total_results")]
        public int total_results {get;set;}
        [JsonPropertyName("total_pages")]
        public int totalPages {get;set;}
    }
}