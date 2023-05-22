namespace MovieFiles.Core.Models;

public class FilterOptions
{
    public int Page { get; set; }

    public string SortBy { get; set; }

    public string ReleaseDateFrom { get; set; }

    public string ReleaseDateTo { get; set; }

    public IList<Genre> Genres { get; set; }
}