namespace MovieFiles.Core.Models;


public class CreditList
{
    public CreditList()
    {
        Id = 0;
        Cast = new Credit[0];
        TotalResults = 0;
    }
    
    public CreditList(int loadingItems = 0)
    {
        var emptyCredits = new List<Credit>();
        for (int i = 0; i < loadingItems; i++)
        {
            emptyCredits.Add(new Credit());
        }
        Cast = emptyCredits.ToArray();
    }
    
    public int Id { get; set; }
    public Credit[] Cast { get; set; }
    public int TotalResults { get; set; }
 
    
    
}