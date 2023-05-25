namespace MovieFiles.Core.Models;

public class GenreList
{
    public GenreList()
    {
        Genres = new Genre[0];
        TotalResults = 0;
    }
    
    public GenreList(int loadingItems = 0)
    {
        var emptyGenres = new List<Genre>();
        for (int i = 0; i < loadingItems; i++)
        {
            emptyGenres.Add(new Genre());
        }
        Genres = emptyGenres.ToArray();
    }
     public Genre[] Genres { get; set; }
    // public List<Genre> Genres {get;set;}
    public int TotalResults { get; set; }

}