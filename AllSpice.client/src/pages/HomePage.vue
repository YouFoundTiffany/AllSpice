<template>
  <div class="container pt-2">

    <!-- STUB Banner section -->
    <section class="row">
      <div class="col-12 bannerImg shadow">
        <!-- Search bar and user icon row -->
        <div class="row justify-content-end p-3">
          <div class="col-md-5 m-0">

            <!-- STUB Search bar -->
            <!-- TODO -->
            <form @submit.prevent="getFavorites()" action="">
              <!-- TODO v-model="editable.query" add back in when ready -->
              <input @click="search()" placeholder="Search" id="searchBar" type="text" required minlength="2"
                class="w-50 m-0 p-0 text-bottom" style="height: 37px;" />
              <button class="btn bg-RussianGreen" type="submit">
                <i class="mdi mdi-magnify m-0 p-0"></i>
              </button>
            </form>
          </div>
          <div class="col-md-2">

            <!-- STUB LOGIN COMPONENT HERE -->
            <div class="user-icon bg-Nutmeg rounded text-center">
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

    <!-- Filter Buttons section -->
    <section class="my-4">
      <div class="container">
        <div class="row justify-content-center" style="margin-top: -50px;">
          <div class="col-6 d-flex justify-content-between">
            <button class="col-5 btn btn-outline-light bg-Vermillion" @click="filterBy = ''">All</button>
            <button class="col-5 btn btn-outline-light bg-Vermillion" @click="filterBy = 'favorites'">Favs</button>
          </div>
        </div>
      </div>
    </section>
  </div>

  <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        ...
      </div>
    </div>
  </div>
  <!-- STUB CREATE RECIPE COLLAPSE -->
  <!-- <div class="container "> -->
  <!-- <div class="row" v-if="user.isAuthenticated">
    <CultForm />
  </div>
  </div> -->
  <!-- STUB RECIPE CARDS -->
  <section class="container-fluid">
    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-3 mb-3">
        <RecipeCard :recipeProp="recipe" :ingredientsProp="ingredients" :favoritesProp="favorites" />
      </div>
    </div>
  </section>
  <!-- STUB End RECIPE CARDS -->
</template>

<script>
import { onMounted, computed } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import RecipeCard from '../components/RecipeCard.vue';
import Login from '../components/Login.vue';
// import { favoritesService } from '../services/FavoritesService.js';
// import { accountService } from '../services/AccountService';

export default {

  // STUB SETUP
  setup() {
    // STUB Variables and OnMounteds
    const ingredients = computed(() => AppState.ingredients);
    const favorites = computed(() => AppState.favorites);
    onMounted(() => {
      getRecipes();
      // getFavorites();
      getIngredients();
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
    // async function getMyFavorites() {
    //   try {
    //     await accountsService.getMyFavorites()
    //   } catch (error) {
    //     Pop.error(error);
    //   }
    // }

    // STUB Returns
    return {
      ingredients,
      favorites,
      // NOTE SEE WEEK 7 latesummer23-postIt Home Page TiffTag
      // filterBy,
      // account: computed(() => AppState.account),
      // TODO WHERE I WILL ADD FILTER
      // recipes: computed(() => {
      //   if (!filterBy.value) {
      //     return AppState.recipes
      //   } else {
      //     return AppState.recipes.filter(recipe => recipe.category == filterBy.value)
      //   }
      // }),
      user: computed(() => AppState.user),
      recipes: computed(() => AppState.recipes),
      ingregients: computed(() => AppState.ingredients),
      // favorites: computed(() => AppState.favorites),


    }

  },
  // STUB Components
  components: { RecipeCard, Login },

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
