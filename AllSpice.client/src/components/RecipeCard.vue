<template>
    <div class="container ">
        <!-- TODO add router link -->
        <div class="row">
            <!-- SECTION Recipe details -->
            <div v-if="recipeProp" class="col-md-6 card">
                <!-- {{ recipeProp }} -->
                <div class="mb-2">
                    <img :src="recipeProp.img" :alt="recipeProp.title" class="coverImg rounded light-shadow">
                    <div>

                        <div class="rounded bg-warning p-1 light-shadow">
                            <p class="">
                                {{ recipeProp.title }}
                            </p>
                            <p class="fs-4">
                                by: {{ recipeProp.creator.name }}
                            </p>
                        </div>
                        <div class="pt-3 ">
                            <!-- TODO disable or HIDE button if not recipe creator OR favorite -->
                            <button v-if="recipeProp.creatorId == account.id || isfavorite"
                                :disabled="recipeProp.archived == true" data-bs-toggle="modal"
                                data-bs-target="#createIngredientModal" class="picture-btn fs-5"><i
                                    class="mdi mdi-plus-box"></i> add
                                Ingredient</button>
                        </div>
                    </div>
                </div>
                <div class="d-flex pt-2">
                    <div class="rounded bg-info light-shadow p-2">
                        <h2>Favorites: {{ recipeProp.memberCount }}</h2>
                    </div>
                    <button v-if="!isFavorite" class="btn btn-secondary" @click="makeFavorite()">Favorite <i
                            class="mdi mdi-heart"></i></button>
                    <button v-else class="btn btn-secondary" @click="unmakeFavorite()">Un-Favorite <i
                            class="mdi mdi-heart-broken"></i></button>
                </div>
            </div>
            <!-- SECTION Recip pictures -->
            <div class="col-md-9">
                <div class="row">
                    <!-- REVIEW these two lines were how we created a 'dummy' for-loop to test our styling -->
                    <!-- <div class="col-3 p-2" v-for="n in 10"> -->
                    <!-- <img class="recip-picture" :src="pictures[0].imgUrl" alt=""> -->
                    <!-- <div class="col-3 p-2" v-for="p in pictures"> -->
                    <!-- below was actual final element -->
                    <!-- <img class="recipe-picture" :src="p.imgUrl" alt=""> -->
                    <!-- </div> -->
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { AppState } from '../AppState.js';
import { Ingredient } from '../models/Ingredient.js';
import { Favorite } from '../models/Favorite.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import { favoritesService } from '../services/FavoritesService.js';



export default {
    // STUB Props
    props: {
        recipeProp: { type: Object, required: true }, ingredientsProp: { type: Array, required: true }, favoritesProp: { type: Array, required: true }
    },
    // STUB Get Ingredients
    async getIngredients() {
        try {
            await ingredientsService.getIngredients();
        } catch (error) {
            Pop.error(error);
        }
    },
    // STUB Get Favorites
    async getFavorites() {
        try {
            await favoritesService.getFavorites();
        } catch (error) {
            Pop.error(error);
        }
    },

    // STUB SETUP!
    setup(props) {
        return {
            // STUB Computeds
            user: computed(() => AppState.user),
            account: computed(() => AppState.account),
            isFavorite: computed(() => AppState.activeRecipeFavorites.find(favorite => favorite.accountId == AppState.account.id)),

            // STUB Active Recipe
            async archiveRecipe() {
                try {
                    const recipeToArchive = await Pop.confirm(`Are you sure you want to archive the ${props.recipeProp.title}?`)

                    if (!recipeToArchive) {
                        return
                    }

                    const recipeId = props.recipeProp.id
                    // logger.log(recipeId)
                    await recipesService.archiveRecipe(recipeId)
                } catch (error) {
                    Pop.error(error.message)
                }
            },
            // STUB Set Recipe to Edit
            setRecipeToEdit() {
                const recipeToEdit = props.recipeProp
                recipesService.setRecipeToEdit(recipeToEdit)
            }



        }
    }

}




</script>

<style scoped>
.coverImg {
    max-height: 170px;
    width: 100%;
    object-fit: cover;
    object-position: center;
    grid-column: 1/1;
    grid-row: 1/1;
    height: 100%;
    object-fit: cover;
}


.square-card {
    width: 200px;
    /* Adjust the card width as needed */
}

.card-img-wrapper {
    position: relative;
    overflow: hidden;
}

.mdi-heart {
    position: absolute;
    top: 10px;
    right: 10px;
    font-size: 24px;
}

.category-pill {
    position: absolute;
    top: 10px;
    left: 10px;
    background-color: rgba(0, 0, 0, 0.7);
    /* Adjust the background color and opacity */
    padding: 5px 10px;
    border-radius: 20px;
}

.category-pill span {
    color: #fff;
    /* Adjust the text color */
}

.blurred-text {
    filter: blur(5px);
    /* Adjust the blur amount as needed */
    background-color: rgba(0, 0, 0, 0.5);
    /* Adjust the background color and opacity */
    padding: 5px;
    border-radius: 5px;
    color: #fff;
    /* Adjust the text color */
    text-align: center;
}
</style>
