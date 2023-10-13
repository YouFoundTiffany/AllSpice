
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

    internal void DeleteFavorite(int favoriteId, string userId)
    {
        Favorite foundFavorite = _repo.GetById(favoriteId);
        if (foundFavorite == null) throw new Exception("Invalid Favorite Id");
        if (foundFavorite.AccountId != userId) throw new Exception("Unauthorized");
        int rows = _repo.DeleteFavorite(favoriteId);
        if (rows > 1) throw new Exception("Something went wrong, less than");
        if (rows > 1) throw new Exception("Something went wrong, greater than");
    }

    internal List<RecipeFavoriteViewModel> GetRecipesByAccount(string accountId)
    {
        List<RecipeFavoriteViewModel> myRecipes = _repo.GetRecipesByAccount(accountId);
        return myRecipes;
    }


    // NOTE see on Favorites Repository and Recipes Controller
    internal List<AccountFavoriteViewModel> GetFavoritesByRecipeId(int recipeId)
    {
        List<AccountFavoriteViewModel> favorites = _repo.GetFavoritesByRecipeId(recipeId);
        return favorites;
    }



}