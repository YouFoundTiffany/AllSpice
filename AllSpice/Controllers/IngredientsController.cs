namespace AllSpice.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0)
    {
        _ingredientsService = ingredientsService;
        _auth0 = auth0;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            ingredientData.CreatorId = userInfo.Id;
            Ingredient newIngredient = _ingredientsService.CreateIngredient(ingredientData);
            // ? newIngredient.Creator = userInfo;
            return newIngredient;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Ingredient>> GetAllIngredients()
    {
        try
        {
            List<Ingredient> ingredients = _ingredientsService.GetAllIngredients();
            return ingredients;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpGet("{ingredientId}")]
    public ActionResult<Ingredient> GetIngredientById(int ingredientId)
    {
        try
        {
            Ingredient ingredient = _ingredientsService.GetIngredientById(ingredientId);
            return Ok(ingredient);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


    [HttpDelete("{ingredientId}")]
    public ActionResult<string> RemoveIngredient(int ingredientId)
    {
        try
        {
            Ingredient ingredient = _ingredientsService.RemoveIngredient(ingredientId);

            return Ok($"{ingredient} was deleted");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }

    }
}