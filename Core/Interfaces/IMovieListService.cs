using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Core.Models;


namespace MovieFiles.Core.Interfaces
{
    public interface IMovieListService
    {
        /// <summary>
        /// method to add a movie to list of movies to watch later
        /// </summary>
        /// <param name="movieId">movie to add to the list</param>
        /// <param name="userId">user who's list to add it to</param>
        /// <returns>true if the addition was succesfull</returns>
        public Task<bool> AddMovieToMyList(MyMovieListItem movieToAdd);

        /// <summary>
        /// method to remove movie from watch later list
        /// </summary>
        /// <param name="movieId">id of movie that should not be in the list of user anymore</param>
        /// <param name="userId">user who's list we want to remove movie from</param>
        /// <returns>true if a movie has been removed from the list</returns>
        public Task<bool> RemoveMovieFromMyList(MyMovieListItem movieToRemove);

        /// <summary>
        /// method to get list of movies in a list of watch later for a specific user
        /// </summary>
        /// <param name="userId">the user that we want to get list of</param>
        /// <param name="page"> page that we want to see</param>
        /// <returns>object containg page information and list of movies for the particular user</returns>
        public Task<CustomMovieList<MyMovieListItem>> GetMyMovieList(Guid userId, MyMovieListItem.ListType listType, int page);
    }
}