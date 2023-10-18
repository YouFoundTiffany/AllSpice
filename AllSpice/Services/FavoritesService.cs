
namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repo;
    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }
    // Check
    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite newFavorite = _repo.CreateFavorite(favoriteData);
        return newFavorite;
    }

    // FIXME
    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favorite = _repo.GetFavoriteById(favoriteId);
        if (favorite == null)
        {
            throw new Exception($"{favoriteId} is not a valid ID");
        }
        return favorite;
    }

    // NOTE see on Favorites Repo and Account Controller
    internal List<RecipeFavoriteViewModel> GetRecipesByAccount(string userId)
    {
        List<RecipeFavoriteViewModel> myRecipes = _repo.GetRecipesByAccount(userId);
        return myRecipes;
    }


    // NOTE see on Favorites Repository and Recipes Controller
    internal List<AccountFavoriteViewModel> GetFavoritesByRecipeId(int recipeId)
    {
        List<AccountFavoriteViewModel> favorites = _repo.GetFavoritesByRecipeId(recipeId);
        return favorites;
    }


    // Check
    internal void DeleteFavorite(int favoriteId, string userId)
    {
        Favorite foundFavorite = _repo.GetFavoriteById(favoriteId);
        if (foundFavorite == null) throw new Exception("Invalid Favorite Id");
        if (foundFavorite.AccountId != userId) throw new Exception("Unauthorized");
        int rows = _repo.DeleteFavorite(favoriteId);
        if (rows > 1) throw new Exception("Something went wrong, less than");
        if (rows > 1) throw new Exception("Something went wrong, greater than");
    }
}