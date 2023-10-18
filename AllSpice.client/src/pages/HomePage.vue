<template>
  <div class="container pt-2">

    <!-- STUB Banner section -->
    <section class="row">
      <div class="col-12 bannerImg shadow">
        <!-- Search bar and user icon row -->
        <div class="row justify-content-end p-3">
          <!-- <div class="col-md-5 m-0"> -->
          <!-- STUB Search bar -->
          <!-- <form @submit.prevent="searchRecipes" action=""> -->
          <!-- FIXME get the  -->
          <!-- TODO v-model="editable.query" add back in when ready -->
          <!-- <form @submit.prevent="searchRecipes" class="row">
                <div class="col-12 input-group">
                  <input v-model="searchTerm" type="text" class="form-control" placeholder="search recipes">
                  <button class="btn btn-primary"><i class="mdi mdi-magnify"></i></button>
                </div>
              </form> -->
          <!-- <input @click="search()" placeholder="Search" id="searchBar" type="text" required minlength="2"
              class="w-50 m-0 p-0 text-bottom rounded-start" style="height: 37px;" />
            <button class="btn bg-RussianGreen" type="submit">
              <i class="mdi mdi-magnify m-0 p-0"></i>
            </button>
            </form> -->
          <!-- </div> -->

          <!-- STUB LOGIN COMPONENT HERE -->
          <div class="col-md-2">
            <div class="user-icon bg-Nutmeg rounded text-center col-md-2 col-6">
              <Login />
            </div>
          </div>
        </div>

        <!-- STUB Banner title and paragraphs -->
        <div class="banner-content text-center pb-2">
          <div class="blurred-shape">
            <img alt="logo" src="../assets/img/asHoriLogoLighTxtShadow.svg" height="200"
              class="mb-4 smscreenoverflow large-screen" />
          </div>
        </div>
      </div>
    </section>

    <!-- STUB Filter Buttons Bar section -->
    <section class="my-4">
      <div class="container">
        <div class="row" style="margin-top: -50px;">
          <div class="col-12 d-flex justify-content-center">
            <button class="col-md-2 col-6 btn btn-outline-light bg-Vermillion selectable"
              @click="filterBy = ''">All</button>
            <button class="col-md-2 col-6 btn btn-outline-light bg-Vermillion selectable"
              @click="filterBy = 'favorites'">Favs</button>
          </div>
          <div class="col-12 d-flex justify-content-center">
            <button class="col-md-2 btn btn-outline-light bg-Vermillion selectable"
              @click="filterBy = 'pastries'">Pastries</button>
            <button class="col-md-2 btn btn-outline-light bg-Vermillion selectable"
              @click="filterBy = 'candies'">Candies</button>
            <button class="col-md-2 btn btn-outline-light bg-Vermillion selectable"
              @click="filterBy = 'cookies'">Cookies</button>
            <button class="col-md-2 btn btn-outline-light bg-Vermillion selectable" @click="filterBy = 'icecream'">Ice
              Cream</button>
            <button class="col-md-2 btn btn-outline-light bg-Vermillion selectable"
              @click="filterBy = 'holiday'">Holiday</button>
          </div>
        </div>
      </div>
    </section>
  </div>

  <!-- SECTION CREATE MODAL -->
  <!-- STUB CREATE RECIPE MODAL -->

  <div class="container justify-content-center">
    <!-- modal button -->
    <!-- v-if="user.isAuthenticated" -->
    <div class="row text-center justify-content-center">
      <button type="button" class="btn bg-RussianGreen border-dark selectable col-md-3 col-8 m-3 text-center"
        data-bs-toggle="modal" data-bs-target="#recipeModal">
        Create Recipe
      </button>
      <!-- modal button -->
      <!-- modal -->
      <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h1 class="modal-title fs-5" id="exampleModalLabel">Create Your Recipe!</h1>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
              <!-- STUB Recipe Form -->
              <RecipeForm :recipeProp="recipes" :ingredientsProp="ingredients" :favoritesProp="myFavorites" />
              <!-- STUB Recipe Form -->
            </div>
            <div class="modal-footer">
              <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button> -->
              <!-- <button type="button" class="btn btn-primary">Save changes</button> -->
            </div>
          </div>
        </div>
      </div>
      <!-- modal -->
    </div>
  </div>
  <!-- container divs -->

  <!-- STUB RECIPE CARDS -->
  <section class="container-fluid">
    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-3 mb-3">
        <RecipeCard :recipeProp="recipe" :ingredientsProp="ingredients" :favoritesProp="myFavorites" />
      </div>
    </div>
  </section>
  <!-- STUB End RECIPE CARDS -->
</template>

<script>
import { onMounted, computed, ref } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import RecipeCard from '../components/RecipeCard.vue';
import RecipeForm from '../components/RecipeForm.vue';
import Login from '../components/Login.vue';
import { favoritesService } from '../services/FavoritesService.js';
import { accountService } from '../services/AccountService';

export default {

  // STUB SETUP
  setup() {
    // STUB Variables and OnMounteds
    const ingredients = ref([]);//TESTING
    const filterBy = ref('')
    const recipesProp = computed(() => AppState.recipes);
    const ingredientsProp = computed(() => AppState.ingredients);
    const favoritesProp = computed(() => AppState.favorites);
    const recipe = ref(null);
    onMounted(() => {
      getRecipes();
      getIngredients();
      // getFavorites();
      // getMyFavorites();
    })

    // STUB Get Recipes Function
    async function getRecipes() {
      // debugger
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error);
      }
    }

    // STUB GEt All Favorites
    // ANCHOR don't need this dude
    // async function getFavorites() {
    //   // debugger
    //   try {
    //     await favoritesService.getFavorites();
    //   } catch (error) {
    //     Pop.error(error);
    //   }
    // }

    // STUB Get Ingredients Function
    async function getIngredients() {
      try {
        await ingredientsService.getIngredients();
      } catch (error) {
        Pop.error(error);
      }
    }

    // STUB Get My Favorites Function
    // ANCHOR don't need this here....this happens in the authService
    // async function getMyFavorites() {
    //   try {
    //     await accountService.getMyFavorites()
    //   } catch (error) {
    //     Pop.error(error);
    //   }
    // }
    // STUB Returns
    return {
      filterBy,
      recipes: computed(() => {
        if (!filterBy.value) {
          return AppState.recipes
        } else {
          return AppState.recipes.filter(recipe => recipe.category == filterBy.value)
        }
      }),
      user: computed(() => AppState.user),
      // myFavorites:computed(()=>AppState.myFavorites),
      // recipes: computed(() => AppState.recipes),
      ingredients: computed(() => AppState.ingredients),
      isFavorite: computed(() => AppState.isFavorite),
      myFavorites: computed(() => AppState.myFavorites),


    }

  },
  // STUB Components
  components: { RecipeCard, Login, RecipeForm },

}
</script>


<style scoped lang="scss">
.shadow {
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  /* Adjust the values as needed */
}


.smscreenoverflow {
  object-fit: contain;
  object-position: center center;
  max-width: 80%;
}

.bannerImg {
  background-image: url("src/assets/img/love.jpg");
  max-height: 250vh;
  width: 100%;
  object-fit: cover;
  background-position: center bottom;
  background-size: cover;
  background-repeat: no-repeat;
  border-radius: 10px !important;
}

// /* Media query for screens below 600px */
// @media screen and (max-width: 599px) {
//   .large-screen {
//     display: none;
//   }

//   .small-screen {
//     display: block;
//   }
// }



// /* Media query for screens below 600px */
// @media screen and (max-width: 599px) {
//   .bannerImg {
//     background-image: url("src/assets/img/spoons.jpg");
//   }
// }

/* Media query for screens below 600px */
// @media screen and (max-width: 599px) {


// .blurred-shape {
//   position: relative;
//   display: inline-block;
//   filter: blur(10px);
//   /* Adjust the blur radius as needed */
//   background-color: rgba(255, 255, 255, 0.8);
//   /* Adjust the color and opacity as needed */
//   border-radius: 50%;
//   /* Creates a circular shape */
//   width: 220px;
//   /* Adjust the width and height to match the logo size */
//   height: 220px;
//   margin: 0 auto;
//   /* Center the shape */
//   z-index: -1;
//   /* Place it behind the content */
// }
</style>
