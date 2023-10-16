import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { Ingredient } from "../models/Ingredient.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
// import { favoritesService } from "./FavoritesService.js"
// import { ingredientsService } from "./IngredientsService.js"


class RecipesService {
    // STUB createRecipe
    async creatRecipe(recipeData) {
        const response = await api.post('api/recipes', recipeData)
        logger.log(response.data)
        const newRecipe = new Recipe(response.data)
        AppState.recipes.unshift(newRecipe)
        return newRecipe
    }

    // STUB Get Recipes
    async getRecipes() {
        const response = await api.get('api/recipes')
        logger.log('[GOT RECIPES]', response.data)
        AppState.recipes = response.data.map(recipe => new Recipe(recipe))
    }

    // STUB Get Recipe By Id
    async getRecipeById(recipeId) {
        const response = await api.get(`api/recipes/${recipeId}`)
        logger.log('[GOT SINGLE RECIPE BY ID]', response.data)
        AppState.activeRecipe = new Recipe(response.data)
    }
    // STUB Get Ingredients By Recipe Id
    async getIngredientsByRecipeId(recipeId) {
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('[GOT INGREDIENTS RECIPE BY ID]', response.data)
        AppState.activeRecipeIngredients = response.data.map(ingredient => new Ingredient(ingredient))
    }

    // STUB Get Favorites By Recipe Id
    async getFavoritesByRecipeId(recipeId) {
        const response = await api.get(`api/albums/${recipeId}/favorites`)
        logger.log('[GOT FAVORITE BY RECIPE ID]', response.data)
        AppState.activeAlbumCollaborators = response.data.map(favorite => new Favorite(favorite))
    }

    // STUB Delete Archive Recipe
    async archiveResponse(recipeId) {
        const response = await api.delete(`api/recipes/${recipeId}`)
        logger.log('[DELETED RECIPE]', response.data)
        // FIXME NEED TO ADD TO OR MAKE WTIH A PUSH OR SOMETHNG
    }


}
export const recipesService = new RecipesService()