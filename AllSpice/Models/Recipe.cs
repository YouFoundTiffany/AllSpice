namespace AllSpice.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Instructions { get; set; }
    public string CoverImg { get; set; }
    public string Category { get; set; }
    public string CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Account Creator { get; set; }


}