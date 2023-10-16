namespace AllSpice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repo;
    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient newIngredient = _repo.CreateIngredient(ingredientData);
        return newIngredient;
    }

    internal List<Ingredient> GetAllIngredients()
    {
        List<Ingredient> ingredients = _repo.GetAllIngredients();
        return ingredients;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _repo.GetIngredientById(ingredientId);
        if (ingredient == null)
        {
            throw new Exception($"{ingredientId} is not a valid ID");
        }
        return ingredient;
    }

    internal Ingredient RemoveIngredient(int ingredientId)
    {
        // NOTE runs the null check for us before sending off the delete request
        Ingredient ingredient = GetIngredientById(ingredientId);
        _repo.RemoveIngredient(ingredientId);
        return ingredient;
    }
}