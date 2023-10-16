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
            return Ok(newRecipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> Get()
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetAllRecipes();
            return Ok(recipes);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB Edit Recipe

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.GetRecipeById(recipeId);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


    // NOTE see below on Ingredient Service and Ingredient Repo
    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
            return Ok(ingredients);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // NOTE see on Favorites Service and Favorites Repository
    [HttpGet("{recipeId}/favorites")]
    public ActionResult<List<AccountFavoriteViewModel>> GetFavoritesByRecipeId(int recipeId)
    {
        try
        {
            List<AccountFavoriteViewModel> favorites = _favoritesService.GetFavoritesByRecipeId(recipeId);
            return Ok(favorites);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{recipeId}")]
    public ActionResult<Recipe> UpdateRecipe(int recipeId, [FromBody] Recipe recipeData)
    {
        try
        {
            Recipe recipe = _recipesService.UpdateRecipe(recipeId, recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


    [Authorize]
    [HttpDelete("{recipeId}")]
    public async Task<ActionResult<Recipe>> ArchiveRecipe(int recipeId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Recipe recipe = _recipesService.ArchiveRecipe(recipeId, userInfo.Id);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


}