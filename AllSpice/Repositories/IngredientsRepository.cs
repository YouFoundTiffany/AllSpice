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
        (name, accountId, recipeId)
        VALUES
        (@name, @accountId, @recipeId)
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




}