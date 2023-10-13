namespace AllSpice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {

        string sql = @"
        INSERT INTO recipes (title, instructions, category, creatorId)
        VALUES
        (@title, @instructions, @category, @creatorId);

        SELECT
        act.*,
        rec.*
        FROM recipes rec
        JOIN accounts act ON act.id = rec.creatorId
        WHERE rec.id = LAST_INSERT_ID();";
        Recipe newRecipe = _db.Query<Account, Recipe, Recipe>(sql, (Account, recipe) =>
        {
            recipe.Creator = Account;
            return recipe;
        }, recipeData).FirstOrDefault();
        return newRecipe;
    }
}