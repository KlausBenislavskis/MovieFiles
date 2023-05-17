﻿

namespace MovieFiles.Api.Client.Services;

public interface IMoviesService
{
    Task<Models.MovieList> GetFavoriteMoviesAsync(int page);
    Task<Models.MovieList> SearchMoviesAsync(int page, string query);
    
}