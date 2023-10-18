<template>
    <form @submit.prevent="createRecipe()">
        <div class="mb-3">
            <label for="title" class="form-label">Title</label>
            <input v-model="recipeData.title" required type="text" class="form-control" id="title" placeholder="Title..."
                maxlength="75" minlength="3">
        </div>
        <div class="mb-3">
            <label for="instructions" class="form-label">Instructions</label>
            <textarea v-model="recipeData.instructions" required type="text" class="form-control" id="instructions"
                placeholder="Instructions..." maxlength="1000" minlength="3" rows="10"></textarea>
        </div>
        <div class="mb-3">
            <label for="coverImg" class="form-label">CoverImg</label>
            <input v-model="recipeData.img" required type="url" class="form-control" id="coverImg" placeholder="CoverImg..."
                maxlength="250" minlength="3">
        </div>
        <!-- STUB Archive -->
        <!-- <div class="mb-3">
            <label for="Archived" class="form-label">Archive</label>
            <input v-model="recipeData.archived" required type="checkbox" class="form-chekcbox" id="archived"
                placeholder="Archived...">
        </div> -->
        <select v-model="recipeData.category" required class="form-select mb-3" aria-label="Default select example">
            <option selected disabled value="">Open this select menu</option>
            <option v-for="category in categories" :key="category" :value="category">
                {{ category }}
            </option>
        </select>

        <div class="text-end">
            <button class="btn btn-success" type="submit">Submit</button>
        </div>
    </form>
</template>


<script>
import { ref, onMounted, computed, watchEffect } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { Modal } from 'bootstrap';
import { useRouter } from 'vue-router';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';

export default {
    // STUB Props
    props: {
        recipeProp: { type: Object, required: false }
    },

    setup(props) {
        // STUB Props
        const recipeData = ref({})
        const router = useRouter()

        // STUB Reset Form
        function resetForm() {
        }

        watchEffect(() => {
            if (AppState.activeRecipe) {
                recipeData.value = AppState.activeRecipe
            }
        })

        // STUB OnMounted
        onMounted(() => {
            resetForm()
        });
        return {

            categories: ['pastries', 'candies', 'cookies', 'icecream', 'holiday'],
            recipeData,
            user: computed(() => AppState.user),
            recipes: computed(() => AppState.recipes),
            ingregients: computed(() => AppState.ingredients),
            isFavorite: computed(() => AppState.isFavorite),
            myFavorites: computed(() => AppState.myFavorites),

            // STUB CreateRecipe
            async createRecipe() {
                try {
                    // NOTE getting the new Recipe back from a return in the service layer
                    // const recipeId = props.recipeProp.id
                    if (!recipeData.value.id) {
                        let newRecipe = await recipesService.createRecipe(recipeData.value) // sends form data to service to create
                        Pop.toast('Recipe Created', 'success') // tells the user good job
                        resetForm() // resets the form
                        Modal.getOrCreateInstance('#recipeModal').hide() // closes the modal
                        // FIXME
                        // router.push({ name: 'Recipe Details', params: { recipeId: newRecipe.id } })
                    } else {
                        // NOTE do the put request here
                        logger.log('editing not creating')
                    }
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
}

</script>


<style lang="scss" scoped></style>