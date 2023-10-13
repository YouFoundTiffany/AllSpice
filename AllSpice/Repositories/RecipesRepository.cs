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
            INSERT INTO recipes
                (title, instructions, img, category, creatorId)
            VALUES
                (@title, @instructions, @img, @category, @creatorId);

            SELECT act.*, rec.*
            FROM recipes rec
            JOIN accounts act ON act.id = rec.creatorId
            WHERE rec.id = LAST_INSERT_ID();";
        Recipe newRecipe = _db.Query<Account, Recipe, Recipe>(sql, (account, recipe) =>
        {
            recipe.Creator = account;
            return recipe;
        }, recipeData).FirstOrDefault();
        return newRecipe;
    }
    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
            SELECT rec.*, act.*
            FROM recipes rec
            JOIN accounts act ON act.id = rec.creatorId;";
        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT rec.*, act.*
        FROM recipes rec
        JOIN accounts act ON rec.creatorId = act.id
        WHERE rec.id = @recipeId
        ;";
        Recipe foundRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
        {
            recipe.Creator = creator;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return foundRecipe;
    }
    // internal void UpdateRecipe(Recipe recipe)
    // {
    //     string sql = @"
    //     UPDATE recipes
    //     SET
    //     title = @title,
    //     instructions = @instructions,
    //     img = @img,
    //     category = @category,
    //     WHERE id = @id
    //     LIMIT 1;
    //     ;";
    //     _db.Execute(sql, recipe);
    // }

    // STUB Edit Recipe
    internal Recipe UpdateRecipe(Recipe originalRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category,
        WHERE id = @id
        LIMIT 1;
    SELECT * FROM recipes WHERE id=i@d
        ;";

        // NOTE From GregsList - we run QueryFirstOrDefault here so that we update the car and then select that car so that we have proper updatedAt timestamps

        Recipe updatedRecipe = _db.QueryFirstOrDefault<Recipe>(sql, originalRecipe);

        return updatedRecipe;
    }



}

