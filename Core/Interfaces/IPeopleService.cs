using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Core.Models.People;

namespace MovieFiles.Core.Interfaces
{
    public interface IPeopleService
    {
        public Task<PeopleList?> GetPopularPeople(int page);
        public Task<PeopleList?> SearchPeople(string query);
    }
}