<template>
    <div class="container-fluid col-12" style="height: 347px">
        <!-- TODO add router link -->
        <div class="row">
            <!-- SECTION Recipe details -->
            <div v-if="recipeProp" class="col-md-12 card elevation-3 p-0">
                <!-- {{ recipeProp }} -->
                <div class="mb-2">
                    <img :src="recipeProp.img" :alt="recipeProp.title" class="coverImg light-shadow">
                    <div>

                        <div class="bg-MochaSlate p-1 txt-LghtMochaSlate text-center">
                            <h5 class="">
                                {{ recipeProp.title }}
                            </h5>
                            <p class="cat-oval fs-6 p-2 fw-bold rounded-pill bg-MochaSlate">
                                {{ recipeProp.category }}
                            </p>
                        </div>
                        <div class="pt-3 ">
                            <!-- TODO  -->
                            <!-- <button v-if="recipeProp.creatorId == account.id || isfavorite"
                                :disabled="recipeProp.archived == true" data-bs-toggle="modal"
                                data-bs-target="#createIngredientModal" class="picture-btn fs-5"><i
                                    class="mdi mdi-plus-box"></i> add
                                as a Favorite</button> -->

                        </div>
                    </div>
                </div>
                <ModalWrapper id="create-recipe" v-if="user.isAuthenticated">
                    <template #button>
                        <button type="button" class="btn btn-primary" data-toggle="modal"
                            data-target=".bd-example-modal-lg">Large
                            modal</button>
                        <i class="mdi mdi-plus-box"></i> Create Recipe
                    </template>

                    <template #body>
                        <RecipeForm />
                    </template>
                </ModalWrapper>
                <div class="d-flex pt-2 justify-content-end">
                    <!-- STUB member count -->
                    <!-- <div class="rounded p-2"> -->
                    <!-- <h2>Favorites: {{ recipeProp.memberCount }}</h2> -->
                    <!-- </div> -->
                    <button v-if="!isFavorite" class="btn bg-RussianGreen m-1" @click="createFavorite()">Favorite <i
                            class="mdi mdi-heart"></i></button>
                    <button v-else class="btn btn-secondary m-1 bg-RussianGreen" @click="removeFavorite()">Un-Favorite <i
                            class="mdi mdi-heart-broken"></i></button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { computed, } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import { favoritesService } from '../services/FavoritesService.js';
import ModalWrapper from './ModalWrapper.vue';
// import { Ingredient } from '../models/Ingredient.js';
// import { Favorite } from '../models/Favorite.js';
// import { Recipe } from '../models/Recipe.js';
// import { logger } from '../utils/Logger';
// import { useRoute } from 'vue-router';


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


        // STUB Return
        return {
            // STUB Computeds
            user: computed(() => AppState.user),
            account: computed(() => AppState.account),
            isFavorite: computed(() => AppState.activeRecipeFavorites.find(favorite => favorite.accountId == AppState.account.id)),

            // STUB Archive Recipe
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
            },
            // STUB Create Favorite
            async createFavorite() {
                try {
                    // inProgress.value = true
                    let favoriteData = { recipeId: route.params.recipeId }
                    await favoritesService.createFavorite(favoriteData)
                    // inProgress.value = false
                } catch (error) {
                    Pop.error(error)
                }
            },
            // STUB Remove Favorite
            async removeFavorite() {
                try {
                    // NOTE need to find the collab in the appstate that is ours, and delete it by it's id
                    let favorite = AppState.activeRecipeFavorites.find(favorite => favorite.accountId == AppState.account.id)
                    await favoritesService.removeFavorite(favorite.id)
                } catch (error) {
                    Pop.error(error)
                }
            }


        }
    },
    components: { ModalWrapper },
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

.mdi-heart {
    position: absolute;
    top: 10px;
    right: 20px;
    font-size: 24px;
    color: red;
}

.cat-oval {
    position: absolute;
    top: 10px;
    right: 215px;
    font-size: 24px;
    border: var(--UltraDrkNutment);
    border-style: solid;
}

.category-pill {
    position: absolute;
    top: 10px;
    left: 10px;
    background-color: rgba(0, 0, 0, 0.7);
    padding: 5px 10px;
    border-radius: 20px;
    text-align: start;
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

@media screen and (max-width: 599px) {
    .cat-oval {

        position: absolute;
        top: 10px;
        right: 320px;
        font-size: 24px;
        border: var(--UltraDrkNutment);
        border-style: solid;
    }
}
</style>
