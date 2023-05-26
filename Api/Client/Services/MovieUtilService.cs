using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Api.Client.Mappers;
using MovieFiles.Core.Interfaces;

namespace MovieFiles.Api.Client.Services
{
    public class MovieUtilService : BaseService, IMovieUtilService
    {
        public MovieUtilService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
        {
        }

        public async Task<Core.Models.GenreList> GetGenresAsync()
        {
            if (CachedGenres != null)
            {
                return CachedGenres;
            }

            var response = await _client.GetAllGenreAsync(_functionAppKey);
            CachedGenres = ClientToUi.Map(response);
            return CachedGenres;
        }

        private static Core.Models.GenreList? CachedGenres { get; set; } = null;
    }
}