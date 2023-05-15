using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Core.Interfaces;
using MovieFiles.Core.Models;

namespace MovieFiles.Adapters
{
    public class SearchMovies : ISearchMovies
    {
        private IRatingRepository _ratingRepository;
        public SearchMovies(IRatingRepository ratingRepository){
            _ratingRepository = ratingRepository;
        }

        private static MovieList emptyList = new MovieList(){
                    Page = 0,
                    Results = new Movie[0],
                    TotalPages = 0,
                    TotalResults = 0
                };
        public async Task<MovieList> searchForMovies(string name, int page)
        {
            var apiKey = MovieApiUtil.apiKey;
            if (String.IsNullOrEmpty(apiKey)){
                return emptyList;
            }

            if (page < 1){
                return emptyList;
            }

            using HttpClient client = new HttpClient(); 
            using HttpResponseMessage response = await client.GetAsync($"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&page={page}&query={name}");
            response.EnsureSuccessStatusCode();

            string responseMessage = await response.Content.ReadAsStringAsync();
            MovieList? list = MovieApiUtil.ConvertApiMessage<MovieList>(responseMessage);
            
            if (list == null){
                list = emptyList;
            }
            return list;
        }
    }
}