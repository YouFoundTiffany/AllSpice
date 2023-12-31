namespace AllSpice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
            INSERT INTO ingredients
                (name, quantity, recipeId, accountId)
            VALUES
                (@name, @quantity, @recipeId, @accountId);
            SELECT ing.*, act.*
            FROM ingredients ing
            JOIN accounts act ON act.id = @accountId
            WHERE ing.id = LAST_INSERT_ID();";

        Ingredient newIngredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return newIngredient;
    }

    internal List<Ingredient> GetAllIngredients()
    {
        string sql = @"
        SELECT ing.*, act.*
        FROM ingredients ing
        JOIN accounts act ON act.id = ing.accountId;";

        List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }).ToList();
        return ingredients;
    }
    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT ing.*, act.*
        FROM ingredients ing
        JOIN accounts act ON act.id = ing.accountId
        WHERE recipeId = @recipeId;";
        List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, new { recipeId }).ToList();
        return ingredients;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {

        string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";
        Ingredient ingredient = _db.QueryFirstOrDefault<Ingredient>(sql, new { ingredientId });

        return ingredient;

    }
    internal void RemoveIngredient(int ingredientId)
    {
        string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
        _db.Execute(sql, new { ingredientId });
    }
}