namespace MovieFiles.Core.Models;


public class CreditList
{
    public CreditList()
    {
        Id = 0;
        Cast = new Cast[0];
        Crew = new Crew[0];
        TotalResults = 0;
    }
    
    public CreditList(int loadingItems = 0)
    {
        var emptyCast = new List<Cast>();
        for (int i = 0; i < loadingItems; i++)
        {
            emptyCast.Add(new Cast());
        }
        Cast = emptyCast.ToArray();
        
        var emptyCrew = new List<Crew>();
        for (int i = 0; i < loadingItems; i++)
        {
            emptyCrew.Add(new Crew());
        }
        Crew = emptyCrew.ToArray();
    }
    
    public int Id { get; set; }
    public Cast[] Cast { get; set; }
    public Crew[] Crew { get; set; }
    public int TotalResults { get; set; }
 
    
    
}