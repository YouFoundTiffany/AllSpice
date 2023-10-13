namespace AllSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
            INSTER INTO favorites
                (recipeId, accountId)
            VALUES
                (@recipeId, @accountId);
            SELECT LAST_INSERT_ID();";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId;
        return favoriteData;
    }

    internal int DeleteFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoritesId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { favoriteId });
        return rows;
    }

    // REVIEW
    internal List<RecipeFavoriteViewModel> GetRecipesByAccount(string accountId)
    {
        string sql = @"
        SELECT fav.*, rec.*
        FROM favorites fav
        JOIN recipes rec ON rec.id = fav.recipeId
        WHERE fav.accountId = @accountId
       ;";
        List<RecipeFavoriteViewModel> myRecipes = _db.Query<Favorite, RecipeFavoriteViewModel, RecipeFavoriteViewModel>(sql, (fav, recipe) =>
        {
            recipe.FavoriteId = fav.Id;
            recipe.AccountId = fav.AccountId;
            return recipe;

        }, new { accountId }).ToList();
        return myRecipes;
    }

    internal Favorite GetById(int favoriteId)
    {
        string sql = @"
    SELECT *
    FROM favorites
    WHERE id = @favoritesId
    ;";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }


    // NOTE see on Favorites Service and Recipes Controller
    internal List<AccountFavoriteViewModel> GetFavoritesByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT fav.*, act.*
        FROM favorites fav
        JOIN accounts act ON act.id = fav.accountId
        WHERE fav.recipeId = @recipeId
        ;";
        List<AccountFavoriteViewModel> favorites = _db.Query<Favorite, AccountFavoriteViewModel, AccountFavoriteViewModel>(sql, (favorites, accountFavorites) =>
        {
            accountFavorites.FavoriteId = favorites.Id;
            accountFavorites.RecipeId = favorites.RecipeId;
            return accountFavorites;
        }, new { recipeId }).ToList();
        return favorites;
    }



}