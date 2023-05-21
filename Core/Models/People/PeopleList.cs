using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  MovieFiles.Core.Models.People
{
    public class PeopleList
    {
        public int Page {get;set;}
        public List<Person> Results {get;set;}
        public int TotalPages {get;set;}
        public int TotalResults {get;set;}
    }
}