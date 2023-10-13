namespace AllSpice.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }
    public int RecipeId { get; set; }
    // FIXME Take lower two off
    public string CreatorId { get; set; }
    public Account Creator { get; set; }

}