using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IMoiveListService
    {
        /// <summary>
        /// method to add a movie to list of movies
        /// </summary>
        /// <param name="movieId">movie to add to the list</param>
        /// <param name="userId">user who's list to add it to</param>
        /// <param name="movieType"></param>
        /// <returns>true if the addition was succesfull</returns>
        public Task<bool> AddMovieToMovieList(Guid userId, int movieId, MyMovieListItem.ListType movieType);

        /// <summary>
        /// method to remove movie from a movie list
        /// </summary>
        /// <param name="movieId">id of movie that should not be in the list of user anymore</param>
        /// <param name="userId">user who's list we want to remove movie from</param>
        /// <param name="movieType"></param>
        /// <returns>true if a movie has been removed from the list</returns>
        public Task<bool> RemoveMovieFromMovieList(Guid userId, int movieId, MyMovieListItem.ListType movieType);

        /// <summary>
        /// method to get list of movies in a list of watch later for a specific user
        /// </summary>
        /// <param name="userId">the user that we want to get list of</param>
        /// <param name="page"> page that we want to see</param>
        /// <returns>object containg page information and list of movies for the particular user</returns>
        public Task<Core.Models.MovieList> GetMyMovieList(Guid userId, MyMovieListItem.ListType movieType, int page);

        /// <summary>
        /// Method to convert list of custom movie list to a movie list - all movies are loaded simultanously
        /// </summary>
        /// <param name="externList">list to be converted</param>
        /// <returns>the converted list</returns>
        //public Task<Core.Models.MovieList> ConvertCustomMovieListToMovieList(CustomMovieList<Core.Models.MyMovieListItem> externList);
    }
}