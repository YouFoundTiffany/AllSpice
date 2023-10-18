<template>
    <div class="container-fluid col-12" style="height: 330px">
        <div class="row">
            <div v-if="recipeProp" class="col-md-12 card elevation-3 p-0">
                <div class="mb-2">
                    <img :src="recipeProp.img" :alt="recipeProp.title" class="coverImg light-shadow">
                    <div>
                        <div class="bg-MochaSlate p-1 txt-LghtMochaSlate text-center">
                            <h6 class="p-1 m-0 text-truncate">
                                {{ recipeProp.title }}
                            </h6>
                            <h6 class="p-1 m-0">
                                Category: {{ recipeProp.category }}
                            </h6>
                        </div>
                    </div>
                </div>
                <!-- STUB START OF Buttons -->
                <div class="d-flex pt-2 justify-content-around">

                    <!-- STUB DETAILS MODAL -->
                    <button @click="toggleModal()" data-bs-toggle="modal" data-bs-target="#detailsModal"
                        class="btn rounded-pill border-dark txt-white bg-Vermillion"><span><i
                                class="mdi mdi-eye txt-white txt-LghtMochaSlate"></i></span></button>

                    <div class="modal fade" id="detailsModal" data-bs-backdrop="static" data-bs-keyboard="false"
                        tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="staticBackdropLabel">{{ recipeProp.title }}</h5>
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
                                                        <div class="bg-MochaSlate txt-LghtMochaSlate">
                                                            <p class="fs-6 p-1 text-center">
                                                                Category: {{ recipeProp.category }}
                                                            </p>
                                                            <p class="fs-6 p-1">
                                                                Instructions: {{ recipeProp.instructions }}
                                                            </p>
                                                            <p class="fs-6 p-1">
                                                                Ingredients: {{ recipeProp.name }} {{ recipeProp.quantity }}
                                                            </p>
                                                            <button type="button" class="btn btn-secondary"
                                                                data-bs-dismiss="modal">Close</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer card">
                                                <!-- STUB ARCHIVE RECIPE -->
                                                <form @submit.prevent="archiveRecipe()" class="col-12">
                                                    <div class="mb-3 card text-center">
                                                        <label for="Archived" class="form-label">Archive Recipe?</label>
                                                        <input v-model="recipeToArchive.archived" required type="checkbox"
                                                            class="form-chekcbox" id="archived" placeholder="Archived...">
                                                        <button
                                                            class="col-2 btn btn-success d-flex justify-content-center text-center"
                                                            type="submit">Submit</button>
                                                    </div>
                                                </form>

                                                <!-- STUB CREATE INGREDIENT -->
                                                <form @submit.prevent="createIngredient()">
                                                    <div class="mb-3">
                                                        <label for="name" class="form-label">Name</label>
                                                        <input v-model="ingredientData.name" required type="text"
                                                            class="form-control" id="name" placeholder="Name..."
                                                            maxlength="75" minlength="3">
                                                    </div>
                                                    <div class="mb-3">
                                                        <label for="quantity" class="form-label">Quantity</label>
                                                        <input v-model="ingredientData.quantity" required type="text"
                                                            class="form-control" id="quantity" placeholder="Quantity..."
                                                            maxlength="10" minlength="3">
                                                    </div>
                                                    <div class="text-end">
                                                        <button class="btn btn-success" type="submit">Submit
                                                            INGREDIENT</button>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- STUB LOWER OF BUTTONS -->
                    <!-- v-show -->
                    <div>
                        <button v-if="recipeProp.creatorId == account.id && user.isAuthenticated"
                            @click="editRecipe(recipeProp.id)"
                            class="btn rounded-pill bg-RussianGreen m-1 p-1 align-items-center border-dark">
                            Edit Recipe
                        </button>
                    </div>

                    <!-- STUB FAV AND UN-FAV BUTTONS -->

                    <button v-if="isFavorite && user.isAuthenticated" @click="createFavorite" role="button"
                        class="btn rounded-pill bg-RussianGreen m-1 align-items-center border-dark">Favorite<i class=""></i>
                    </button>

                    <button v-else-if="!isFavorite && user.isAuthenticated" @click="removeFavorite" role="button"
                        class="btn rounded-pill bg-Coral m-1 align-items-center border-dark">Un-Fav<i
                            class="mdi mdi-silverware-spoon"></i></button>

                    <button v-else disabled role="button" class="btn btn-secondary m-1 bg-RussianGreen border-dark"
                        title="Log In To Add Favorite Recipes">Log In<i class="mdi mdi-broken-heart"></i></button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import { favoritesService } from '../services/FavoritesService.js';
import { logger } from '../utils/Logger';
import { useRoute } from 'vue-router';
import { Modal } from 'bootstrap';


export default {
    // STUB Props
    props: {
        recipeProp: { type: Object, required: true }
    },
    // STUB Get Ingredients
    async getIngredients() {
        try {
            await ingredientsService.getIngredients();
        } catch (error) {
            Pop.error(error);
        }
    },
    // STUB Get All Favorites
    async getFavorites() {
        try {
            await favoritesService.getFavorites();
        } catch (error) {
            Pop.error(error);
        }
    },
    // async getMyFavorites() {
    //     try {
    //         await accountService.getMyFavorites()
    //     } catch (error) {
    //         Pop.error(error);
    //     }
    // },


    // STUB SETUP!
    setup(props) {
        const route = useRoute();
        const ingredientData = ref({})
        const recipeToArchive = ref({})
        // const myFavorites = ref({})
        onMounted(() => {
            // this.getFavorites()
        })


        // STUB Return
        return {
            // STUB Computeds
            // AppState: computed(() => AppState),
            ingredientData,
            recipeToArchive,
            showModal: false,
            user: computed(() => AppState.user),
            account: computed(() => AppState.account),
            myFavorites: computed(() => AppState.myFavorites),
            activeRecipeFavorites: (() => AppState.activeRecipeFavorites),
            isFavorite: computed(() => AppState.myFavorites.find(favorite => favorite.id == props.recipeProp.id)),


            // STUB Create Ingredient
            async CreateIngredient() {
                logger.log('click the button?')
                try {
                    logger.log(ingredientData.value, AppState.activeRecipe.id, route.params.recipeId)
                    ingredientData.value.recipeId = route.params.recipeId
                    await ingredientsService.CreateIngredient(ingredientData.value)
                    Pop.toast('Added picture', 'success', 'center-end')
                    ingredientData.value = {}
                    Modal.getOrCreateInstance('#create-picture').hide()
                } catch (error) {
                    Pop.error(error)
                }
            },

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
            // TiffTag
            // STUB Create Favorite
            async createFavorite() {
                try {
                    const recipeId = props.recipeProp.id
                    const quantity = props.recipeProp.quantity;
                    const favoriteData = { recipeId, quantity };
                    logger.log('fav data', favoriteData)
                    await favoritesService.createFavorite(favoriteData)
                } catch (error) {
                    Pop.error(error)
                }
            },
            // STUB Remove Favorite
            async removeFavorite() {
                try {
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
            },

        }
    },

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

.mdi-silverware-spoon {
    position: absolute;
    top: 10px;
    right: 20px;
    font-size: 24px;
    color: red;
    pointer-events: none
}
</style>
