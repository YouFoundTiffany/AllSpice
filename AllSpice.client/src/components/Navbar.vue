<template>
  <nav class="navbar navbar-expand-lg px-3 Lora bg-Vermillion navCorners">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="../assets/img/asLogoOnlyShadow.svg" height="55" />
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <!-- <ul class="navbar-nav me-auto">
        <li class="">
          <router-link :to="{ name: 'About' }" class="btn txt-LghtMochaSlate lighten-30 selectable lghtnavbar-text">
            About
          </router-link>
        </li>
      </ul> -->
      <!-- NOTE MOVED THIS TO BANNER IMAGE -->
      <!-- <div class="p-1">
        <div class="input-group">
          <input class="form-control" type="search" placeholder="Search" aria-label="Search">
          <button class="btn btn-outline-success" type="submit">Search</button>
        </div>
      </div> -->
      <!-- NOTE MOVED LOGIN TO BANNER IMAGE -->
      <!-- LOGIN COMPONENT HERE -->
      <!-- <Login /> -->
    </div>
  </nav>
</template>

<script>
// import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  // components: { Login }
}
</script>

<style scoped>
.lghtnavbar-text {
  font-weight: bold;
  background-color: var(--Vermillion);
  color: var(--MochaSlateghtMochaSlate);
  transition: background-color 0.3s, color 0.3s;
}

.lghtnavbar-text:hover {
  color: var(--LghtMochaSlate);
}

@media screen and (max-width: 599px) {
  .lghtnavbar-text {
    background-color: var(--UltraDrkNutmeg);
  }
}


.navCorners {
  border-radius: 22px;
}

a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--LghtMochaSlate);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;

}


@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
