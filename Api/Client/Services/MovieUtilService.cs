
using MovieFiles.Api.Client.Mappers;
using MovieFiles.Core.Interfaces;


namespace MovieFiles.Api.Client.Services;

public class MovieUtilService :BaseService, IMovieUtilService
{
    public MovieUtilService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey)
    {
    }
    
    public async Task<Core.Models.GenreList?> GetGenresAsync()
    {
        var response = await _client.GetGenresAsync(_functionAppKey); 
        return ClientToUi.Map(response);
    }
}