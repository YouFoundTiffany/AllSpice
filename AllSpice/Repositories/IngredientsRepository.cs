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
            INSTERT INTO ingredients
                (name, quantity, recipeId, creatorId, creator)
            VALUES
                (@name, @quantity, @recipeId, @creatorId,@creator)
            SELECT
            ing.*,
            act.*,
            FROM ingredients ing
            JOIN accounts act On act.id = @creatorId
            WHERE ing.id = LAST_INSTER_ID();";
        Ingredient newIngredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return newIngredient;
    }





    internal List<Ingredient> GetIngredientByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT ing.*, act.*
        FROM ingredient ing
        JOIN accounts act ON act.id = ing.creatorId
        WHERE recipeId = @recipeId;";
        List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, new { recipeId }).ToList();
        return ingredients;
    }


}