<template>
  <div class="container pt-2">
    <!-- STUB Banner section -->
    <section class="row">
      <div class="col-12 bannerImg shadow">
        <!-- Search bar and user icon row -->
        <div class="row justify-content-end p-3">
          <div class="col-md-5">
            <!-- STUB Search bar -->
            <!-- FIXME -->
            <form @submit.prevent="getFavorites()" action="">
              <!-- FIXME v-model="editable.query" add back in when ready -->
              <input @click="search()" placeholder="Search" id="searchBar" type="text" required minlength="2"
                class="w-50" />
              <button class="btn bg-RussianGreen" type="submit">
                <i class="mdi mdi-magnify t"></i>
              </button>
            </form>
          </div>
          <div class="col-md-2">
            <!-- STUB LOGIN COMPONENT HERE -->
            <div class="user-icon bg-Nutmeg rounded text-center ">
              <Login />
            </div>
          </div>
        </div>
        <!-- STUB Banner title and paragraphs -->
        <div class="banner-content text-center pb-2">
          <div class="blurred-shape">
            <img alt="logo" src="../assets/img/asHoriLogoLighTxtShadow.svg" height="200"
              class="mb-4 smscreenoverflow large-screen" />
            <!-- <img alt="logo" src="../assets/img/asHoriLogoDrkTxtShadow.svg" height="200"
              class="mb-4 smscreenoverflow small-screen" /> -->
          </div>
        </div>
      </div>

    </section>

    <!-- Navbar section -->
    <section class="mt-4">
      <div class="container">
        <div class="row justify-content-center" style="margin-top: -50px;">
          <div class="col-6 d-flex justify-content-between">
            <button class="col-5 btn btn-outline-light bg-Vermillion" @click="filterBy = ''">All</button>
            <button class="col-5 btn btn-outline-light bg-Vermillion" @click="filterBy = 'favorites'">Favorites</button>
          </div>
        </div>
      </div>
    </section>
    <!-- NOTE removed as it isn't needed at this time, added the filter buttons in its place. -->
    <!-- <Navbar class="shadow" /> -->
    <!-- </div>
      </section>
    </div> -->
  </div>
  <!-- STUB RECIPE CARDS -->
  <section class="container">
    <div class="row">
      <!-- {{ recipe }} -->

    </div>
  </section>
  <!-- STUB RECIPE CARDS -->
</template>

<script>
// FIXME
// import Login from '../src/components/Login.vue';
// import Navbar from './components/Navbar.vue';

export default {
  setup() {
    return {}
  },
  // FIXME Login ADD TO COMPONENTS
  // components: { Login, Navbar },
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
