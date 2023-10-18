namespace AllSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }
    // Check
    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
            INSERT INTO favorites
                (accountId, recipeId)
            VALUES
                (@accountId, @recipeId);
            SELECT LAST_INSERT_ID();";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId;
        return favoriteData;
    }



    // REVIEW
    //  NOTE see on Favorites Service and Account Controller
    internal List<RecipeFavoriteViewModel> GetRecipesByAccount(string userId)
    {
        string sql = @"
        SELECT
        fav.*,
        rec.*
        FROM favorites fav
        JOIN recipes rec ON rec.id = fav.recipeId
        WHERE fav.accountId = @userId
       ;";
        //    NOTE ^^^^ change creatrId to accountId
        List<RecipeFavoriteViewModel> myRecipes = _db.Query<Favorite, RecipeFavoriteViewModel, RecipeFavoriteViewModel>(sql, (fav, recipe) =>
        {
            recipe.FavoriteId = fav.Id;
            // recipe.AccountId = fav.CreatrId;
            recipe.AccountId = fav.AccountId;
            return recipe;

        }, new { userId }).ToList();
        return myRecipes;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = @"
        SELECT *
        FROM favorites
        WHERE id = @favoriteId
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
    // Check
    internal int DeleteFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { favoriteId });
        return rows;
    }

}