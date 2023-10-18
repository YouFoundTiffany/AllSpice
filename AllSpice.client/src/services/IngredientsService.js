import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService {
    // STUB createIngredient
    async createIngredient(ingredientData) {
        const response = await api.post('api/ingredients', ingredientData)
        logger.log(response.data)
        const newIngredient = new Ingredient(response.data)
        AppState.ingredients.unshift(newIngredient)
        return newIngredient
    }

    // STUB Get Ingredients
    async getIngredients() {
        const response = await api.get('api/ingredients')
        logger.log('[GOT INGREDIENTS]', response.data)
        AppState.ingredients = response.data.map(ingredient => new Ingredient(ingredient))
    }

    // STUB Delete Ingredient
    async archiveIngredient(ingredientId) {
        const response = await api.delete(`api/ingredients/${ingredientId}`)
        logger.log('[DELETED INGREDIENT]', response.data)
        // FIXME NEED TO ADD TO OR MAKE WTIH A PUSH OR SOMETHNG
    }


}
export const ingredientsService = new IngredientsService()