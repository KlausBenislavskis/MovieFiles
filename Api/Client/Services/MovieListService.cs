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

        public Task<bool> AddMovieToMovieList(Guid userId, int movieId, Core.Models.MyMovieListItem.ListType movieType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveMovieFromMovieList(Guid userId, int movieId, Core.Models.MyMovieListItem.ListType movieType)
        {
            throw new NotImplementedException();
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