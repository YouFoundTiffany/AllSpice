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

    internal List<Recipe> Get()
    {
        List<Recipe> recipes = _repo.Get();
        return recipes;
    }

    internal Recipe Get(int albumId)
    {
        Recipe foundRecipe = _repo.Get(recipeId);
        if (foundRecipe == null) throw new Exception($"{recipeId} not found.");
        return foundRecipe;
    }

    internal Recipe ArchiveRecipe(int recipeId, string userId)
    {
        Recipe recipe = this.Get(recipeId);
        if (recipe.CreatorId != userId) throw new Exception("Unauthorized");
        recipe.Archived = !recipe.Archived;
        _repo.Edit(recipe);
        return recipe;
    }












}
