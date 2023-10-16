import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},



  /**@type {[Recipe]} */
  recipes: [],

  /**@type {Recipe} */
  activeRecipe: null,

  /**type @type {Ingredient[]} */
  activeRecipeIngredients: [],

  /**@type {[Ingredient]} */
  ingredients: [],

  /**@type {[Favorite]} */
  favorites: [],

  /**@type {Favorite[]} */
  myFavorites: [],

  /**@type {Favorite[]} */
  activeRecipeFavorites: [],

})
