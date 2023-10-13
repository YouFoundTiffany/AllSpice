namespace AllSpice.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0)
    {
        _favoritesService = favoritesService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            Favorite newFavorite = _favoritesService.CreateFavorite(favoriteData);
            return newFavorite;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [Authorize]
    [HttpDelete("{favoriteId}")]
    public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            _favoritesService.DeleteFavorite(favoriteId, userInfo.Id);
            string message = "Favorite Removed";
            return message;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }



}