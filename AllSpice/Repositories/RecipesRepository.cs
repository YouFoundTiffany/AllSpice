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
                (title, instructions, img, category, creatorId, archived)
            VALUES
                (@Title, @Instructions, @Img, @Category, @CreatorId, @Archived);

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

    // STUB Edit Recipe
    internal Recipe UpdateRecipe(Recipe originalRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        title = @Title,
        instructions = @Instructions,
        img = @Img,
        category = @Category,
        archived = @Archived
        WHERE id = @Id
        LIMIT 1;
        SELECT * FROM recipes WHERE id = @Id
        ;";

        // NOTE From GregsList - we run QueryFirstOrDefault here so that we update the recip and then select that recipe so that we have proper updatedAt timestamps

        Recipe updatedRecipe = _db.QueryFirstOrDefault<Recipe>(sql, originalRecipe);

        return updatedRecipe;
    }
    // STUB ARCHIVE Recipe
    internal Recipe archiveRecipe(Recipe originalRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        archived = @Archived
        WHERE id = @Id
        LIMIT 1;
        SELECT * FROM recipes WHERE id = @Id
        ;";

        // NOTE From GregsList - we run QueryFirstOrDefault here so that we update the recip and then select that recipe so that we have proper updatedAt timestamps

        Recipe updatedRecipe = _db.QueryFirstOrDefault<Recipe>(sql, originalRecipe);

        return updatedRecipe;
    }


    // // STUB Delete Recipe
    // internal void RemoveRecipe(int recipeId)
    // {
    //     string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";

    //     // NOTE Execute will run our sql query and not return anything back
    //     _db.Execute(sql, new { recipeId });
    // }


}

