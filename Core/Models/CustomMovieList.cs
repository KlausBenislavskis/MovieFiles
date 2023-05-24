using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFiles.Core.Models
{
    public class CustomMovieList<T>
    {
        public int Page {get;set;}
        public T[] List {get;set;} = new T[0];
        public int TotalResults {set;get;}
        public int TotalPages {set;get;}
    }
}