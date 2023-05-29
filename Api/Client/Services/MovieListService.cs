using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;
using MovieFiles.Api.Client.Mappers;

namespace MovieFiles.Api.Client.Services
{
    public class MovieListService : BaseService, IMoiveListService
    {
        private IMovieDetailsService _movieDetailService;
        public MovieListService(string httpUrl, string functionAppKey, IMovieDetailsService movieDetailService) : base(httpUrl, functionAppKey)
        {
            _movieDetailService = movieDetailService;
        }

        public async Task<bool> AddMovieToMovieList(Guid userId, int movieId, Core.Models.MyMovieListItem.ListType movieType)
        {
            try {
                string response = await RetryHelper.RetryOnExceptionAsync(3,() => 
                _client.AddMovieToMovieListAsync(userId,movieId,MyMovieListItem.GetListTypeName(movieType),_functionAppKey));
                // for some reson the framework has a problem to read text/plain response
                // and it allways throw exception, so I check the correctness by the status code
                return true;
            } catch (ApiException e){
                if (e.StatusCode == 200){
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> RemoveMovieFromMovieList(Guid userId, int movieId, Core.Models.MyMovieListItem.ListType movieType)
        {
            try {
                string response = await RetryHelper.RetryOnExceptionAsync(3, ()=>
                _client.RemoveMovieFromMovieListAsync(userId,movieId,MyMovieListItem.GetListTypeName(movieType),_functionAppKey));
                // for some reson the framework has a problem to read text/plain response
                // and it allways throw exception, so I check the correctness by the status code
                return true;
            } catch (ApiException e){
                if (e.StatusCode == 200){
                    return true;
                }
                return false;
            }
        }

        public async Task<Core.Models.MovieList> GetMyMovieList(Guid userId, Core.Models.MyMovieListItem.ListType listType, int page)
        {
            MovieList response = await RetryHelper.RetryOnExceptionAsync<MovieList>(3, () => 
                _client.GetMoviesFromMovieListAsync(
                    userId,
                    MyMovieListItem.GetListTypeName(listType),
                    page,
                    _functionAppKey));
            return ClientToUi.Map(response);
        }
    }
}