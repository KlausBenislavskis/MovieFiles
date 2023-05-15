using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MovieFiles.Core.Models
{
    public class MovieList
    {
        // TODO (lukas 15.05.): remove jsonproperties if oneone uses them, as serialisation from 3rd party
        // api no longer depends on it 
        [JsonPropertyName("page")]
        public int Page {get;set;}
        [JsonPropertyName("results")]
        public Movie[] Results {get;set;}
        [JsonPropertyName("total_results")]
        public int TotalResults {get;set;}
        [JsonPropertyName("total_pages")]
        public int TotalPages {get;set;}
    }
}