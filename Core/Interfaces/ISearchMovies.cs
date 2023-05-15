using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface ISearchMovies
    {
        /// <summary>
        /// method to acquire movies based on search name (search is infix)
        /// </summary>
        /// <param name="name">searched term</param>
        /// <param name="page">number of page that you want to get results of</param>
        /// <returns> list of movies including information about page and number of results</returns>
        public Task<MovieList> SearchForMovies(string name,int page);
    }
}