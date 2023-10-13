using System.Security.Cryptography.X509Certificates;

namespace AllSpice.Controllers;

[ApiController]
[Route("api/recipes")]

public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;
    private readonly IngredientsService _ingredientsService;
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0;

    public RecipesController(RecipesService recipesService, Auth0Provider auth0, IngredientsService ingredientsService, FavoritesService favoritesService)

    {
        _recipesService = recipesService;
        _auth0 = auth0;
        _ingredientsService = ingredientsService;
        _favoritesService = favoritesService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe newRecipe = _recipesService.CreateRecipe(recipeData);
            return newRecipe;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }






}