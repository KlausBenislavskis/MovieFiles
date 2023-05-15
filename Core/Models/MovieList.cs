using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MovieFiles.Core.Models
{
    public class MovieList
    {
        public int Page {get;set;}
        public Movie[] Results {get;set;}
        public int TotalResults {get;set;}
        public int TotalPages {get;set;}
    }
}