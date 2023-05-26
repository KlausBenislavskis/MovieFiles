namespace MovieFiles.Core.Models;

public class GenreList
{
    public List<Genre> Genres { get; set; }
    public GenreList Copy(){
        var list = new List<Genre>();
        foreach (Genre item in Genres){
            list.Add(item.Copy());
        }
        return new GenreList(){
            Genres = list
        };
    }
}