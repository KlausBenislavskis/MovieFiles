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

        /// <summary>
        /// this method is just for testing so that @Andrej have some data to show and get
        /// </summary>
        /// <param name="page">number of page to get results of</param>
        /// <returns>List of movies that are on the particular page of the most popular movies</returns>
        public Task<MovieList> GetTestingMovies(int page);
    }
}