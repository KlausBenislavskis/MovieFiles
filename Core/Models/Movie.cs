namespace MovieFiles.Core.Models;

public class Movie
{
    

    public int Id
    {
        get => Id;
        set => Id = value;
    }
    public int ImdbId
    {
        get => ImdbId;
        set => ImdbId = value ;
    }
    
    public string PosterPath
    {
        get => PosterPath;
        set => PosterPath = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string Title
    {
        get => Title;
        set => Title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string OriginalTitle
    {
        get => OriginalTitle;
        set => OriginalTitle = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string ReleaseDate
    {
        get => ReleaseDate;
        set => ReleaseDate = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public double Revenue
    {
        get => Revenue;
        set => Revenue = value;
    }
    public double Budget
    {
        get => Budget;
        set => Budget = value;
    }
    
    public string Overview
    {
        get => Overview;
        set => Overview = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Runtime
    {
        get => Runtime;
        set => Runtime = value;
    }
    public double VoteAverage
    {
        get => VoteAverage;
        set => VoteAverage = value;
    }

    public int VoteCount
    {
        get => VoteCount;
        set => VoteCount = value;
    }
    
    public IList<Genre> Genres
    {
        get => Genres;
        set => Genres = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public IList<ProductionCompany> ProductionCompanies
    {
        get => ProductionCompanies;
        set => ProductionCompanies = value ?? throw new ArgumentNullException(nameof(value));
    }

    
}