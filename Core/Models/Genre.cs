namespace MovieFiles.Core.Models;

public class Genre
{
    public string Id
    {
        get => Id;
        set => Id = value;
    }
    
    public string Name
    {
        get => Name;
        set => Name = value ?? throw new ArgumentNullException(nameof(value));
    }
}