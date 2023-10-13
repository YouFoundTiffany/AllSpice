
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












}
