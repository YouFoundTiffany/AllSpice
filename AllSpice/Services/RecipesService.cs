namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repo;
    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }
    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe newRecipe = _repo.CreateRecipe(recipeData);
        return newRecipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repo.GetAllRecipes();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe foundRecipe = _repo.GetRecipeById(recipeId);
        if (foundRecipe == null) throw new Exception($"{recipeId} not found.");
        return foundRecipe;
    }

    // STUB Edit Recipe
    internal Recipe UpdateRecipe(int recipeId, Recipe recipeData)
    {
        Recipe originalRecipe = GetRecipeById(recipeId);

        originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
        originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
        originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
        originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
        Recipe recipe = _repo.UpdateRecipe(originalRecipe);

        return recipe;
    }

    internal Recipe ArchiveRecipe(int recipeId, string userId)
    {
        Recipe recipe = this.GetRecipeById(recipeId);
        if (recipe.CreatorId != userId) throw new Exception("Unauthorized");
        recipe.Archived = !recipe.Archived;
        _repo.UpdateRecipe(recipe);
        return recipe;
    }


}
