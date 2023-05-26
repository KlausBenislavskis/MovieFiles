namespace MovieFiles.Core.Models;

public class Genre
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public Genre Copy(){
        return new Genre() {
            Id = this.Id,
            Name = this.Name
        };
    }
}