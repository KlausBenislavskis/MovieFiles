using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces;

public interface IMovieUtilService
{
    Task<Genre[]?> GetGenresAsync();
}