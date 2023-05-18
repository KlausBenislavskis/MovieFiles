namespace MovieFiles.Core.Models;

public class CreditList
{
    public CreditList()
    {
        Results = new Credit[0];
        TotalResults = 0;
    }
    
    public CreditList(int loadingItems = 0)
    {
        var emptyCredits = new List<Credit>();
        for (int i = 0; i < loadingItems; i++)
        {
            emptyCredits.Add(new Credit());
        }
        Results = emptyCredits.ToArray();
    }
    

    public Credit[] Results { get; set; }
    public int TotalResults { get; set; }
 
    
    
}