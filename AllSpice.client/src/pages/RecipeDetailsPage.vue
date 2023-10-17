<template>
    <div class='container'>
        <section class='row'>
            <ModalWrapper id="create-recipe" v-if="user.isAuthenticated">
                <template #button>
                    <i class="mdi mdi-plus-box"></i> Create Recipe
                </template>

                <template #body>
                    <RecipeForm />
                </template>
            </ModalWrapper>
        </section>
    </div>
</template>
<script>
// import { route } from 'vue-router';
// import { favoritesService } from '../services/FavoritesService.js';
// import { logger } from '../utils/Logger';
// import { AppState } from '../AppState';
// import Pop from '../utils/Pop';
import ModalWrapper from '../components/ModalWrapper.vue';
export default {
    setup() {
        return {
            // // STUB Create Favorite
            // async createFavorite() {
            //     try {
            //         // inProgress.value = true
            //         let favoriteData = { recipeId: route.params.recipeId } // just creating a body with albumId on it equal to the route params
            //         await favoritesService.createFavorite(favoriteData)
            //         // inProgress.value = false
            //     } catch (error) {
            //         Pop.error(error)
            //     }
            // },
            // // STUB Remove Favorite
            // async removeFavorite() {
            //     try {
            //         // NOTE need to find the collab in the appstate that is ours, and delete it by it's id
            //         let favorite = AppState.activeRecipeFavorites.find(favorite => favorite.accountId == AppState.account.id)
            //         await favoritesService.removeFavorite(favorite.id)
            //     } catch (error) {
            //         Pop.error(error)
            //     }
            // }
        };
    },
    components: { ModalWrapper }
};
</script>


<style></style>