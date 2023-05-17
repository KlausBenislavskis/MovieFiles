namespace MovieFiles.Core.Models;

public class ProductionCompany
{
    public string Id
    {
        get => Id;
        set => Id = value;
    }
    public string LogoPath
    {
        get => LogoPath;
        set => LogoPath = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public string Name
    {
        get => Name;
        set => Name = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string OriginCountry
    {
        get => OriginCountry;
        set => OriginCountry = value ?? throw new ArgumentNullException(nameof(value));
    }
}