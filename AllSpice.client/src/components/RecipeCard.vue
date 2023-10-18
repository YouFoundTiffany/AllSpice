<template>
    <div class="container-fluid col-12" style="height: 347px">
        <div class="row">
            <div v-if="recipeProp" class="col-md-12 card elevation-3 p-0">
                <div class="mb-2">
                    <img :src="recipeProp.img" :alt="recipeProp.title" class="coverImg light-shadow">
                    <div>
                        <div class="bg-MochaSlate p-1 txt-LghtMochaSlate text-center">
                            <h5 class="">
                                {{ recipeProp.title }}
                            </h5>
                            <p class="fs-6 p-2 ">
                                Category: {{ recipeProp.category }}
                            </p>
                        </div>
                    </div>
                </div>
                <!-- STUB Buttons -->
                <div class="d-flex pt-2 justify-content-around">

                    <!-- STUB Details Modal -->
                    <button @click="toggleModal()" data-bs-toggle="modal" data-bs-target="#detailsModal"
                        class="btn rounded-pill border-dark txt-white bg-Vermillion"><span><i
                                class="mdi mdi-eye txt-white txt-LghtMochaSlate"></i></span></button>

                    <div class="modal fade" id="detailsModal" data-bs-backdrop="static" data-bs-keyboard="false"
                        tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal"
                                        aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <div class="container-fluid col-12" style="height: 347px">
                                        <div class="row">
                                            <!-- v-if="recipeProp" -->
                                            <div class="col-md-12 card elevation-3 p-0">
                                                <div class="mb-2">
                                                    <img :src="recipeProp.img" :alt="recipeProp.title"
                                                        class="coverImg light-shadow">
                                                    <div>
                                                        <div class="bg-MochaSlate p-1 txt-LghtMochaSlate text-center">
                                                            <h5 class="">
                                                                {{ recipeProp.title }}
                                                            </h5>
                                                            <p class="fs-6 p-2 ">
                                                                Category: {{ recipeProp.category }}
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary"
                                                    data-bs-dismiss="modal">Close</button>
                                                <button type="button" class="btn btn-primary">Understood</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button @click="editRecipe(recipeProp.id)"
                        class="btn rounded-pill bg-RussianGreen m-1 align-items-center border-dark selectable">
                        Edit Recipe
                    </button>
                    <button v-if="!isFavorite"
                        class="btn rounded-pill bg-RussianGreen m-1 align-items-center border-dark selectable"
                        @click="createFavorite()">Favorite</button>
                    <button v-else class="btn btn-secondary m-1 bg-RussianGreen border-dark"
                        @click="removeFavorite()">Un-Favorite</button>
                    <!-- STUB Buttons End -->

                    <!-- TODO -->
                    <i v-if="!isFavorite" class="mdi mdi-heart"></i>
                    <i v-else class="mdi mdi-heart-broken"></i>
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
// import { Ingredient } from '../models/Ingredient.js';
// import { Favorite } from '../models/Favorite.js';
// import { Recipe } from '../models/Recipe.js';
import { logger } from '../utils/Logger';
import { useRoute } from 'vue-router';
import { Modal } from 'bootstrap';


export default {
    // STUB Props
    props: {
        recipeProp: { type: Object, required: true }, ingredientsProp: { type: Array, required: true }, favoritesProp: { type: Array, required: false }
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
        const route = useRoute();

        // STUB Return
        return {
            // STUB Computeds
            showModal: false,
            user: computed(() => AppState.user),
            account: computed(() => AppState.account),
            favorites: computed(() => AppState.favorites),
            isFavorite: computed(() => AppState.activeRecipeFavorites.find(favorite => favorite.accountId == AppState.account.id)),
            // TODO MOVE TO RECIPE DETAILS MODAL
            // // STUB Archive Recipe
            // async archiveRecipe() {
            //     try {
            //         const recipeToArchive = await Pop.confirm(`Are you sure you want to archive the ${props.recipeProp.title}?`)
            //         if (!recipeToArchive) {
            //             return
            //         }
            //         const recipeId = props.recipeProp.id
            //         // logger.log(recipeId)
            //         await recipesService.archiveRecipe(recipeId)
            //     } catch (error) {
            //         Pop.error(error.message)
            //     }
            // },
            // STUB Set Recipe to Edit
            setRecipeToEdit() {
                const recipeToEdit = props.recipeProp
                recipesService.setRecipeToEdit(recipeToEdit)
            },
            // TiffTag
            // STUB Create Favorite
            async createFavorite() {
                try {
                    // inProgress.value = true
                    const recipeId = props.recipeProp.id
                    // let favoriteData = { recipeId: route.params.recipeId }
                    let favoriteData = { recipeId }
                    logger.log('fav data', favoriteData)
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
            },

            async editRecipe(recipeId) {
                try {
                    // logger.log(recipeId, 'editing recipe')
                    await recipesService.getRecipeById(recipeId)
                    Modal.getOrCreateInstance('#recipeModal').show()
                } catch (error) {
                    Pop.error(error)
                }
            },
            toggleModal(recipeId) {
                Modal.getOrCreateInstance('#detailsModal').show()

                // this.showModal = !this.showModal;
            },

        }
    },
    components: {},
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
    pointer-events: none
}
</style>
