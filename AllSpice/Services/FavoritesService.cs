
namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repo;
    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite newFavorite = _repo.CreateFavorite(favoriteData);
        return newFavorite;
    }

    // NOTE see on Favorites Repository and Recipes Controller
    internal List<AccountFavoriteViewModel> GetFavoritesByRecipeId(int recipeId)
    {
        List<AccountFavoriteViewModel> favorites = _repo.GetFavoritesByRecipeId(recipeId);
        return favorites;
    }



}