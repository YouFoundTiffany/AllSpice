<template>
  <div class="container pt-2">
    <!-- Banner section -->
    <section class="row">
      <div class="col-12 bannerImg shadow">
        <!-- Search bar and user icon row -->
        <div class="row justify-content-end">
          <div class="col-md-4">
            <div class="input-group">
              <input class="form-control py-2 border-right-0 border" type="search" value="search"
                id="example-search-input">
              <span class="input-group-append">
                <div class="input-group-text bg-transparent"><i class="fa fa-search"></i></div>
              </span>
            </div>
          </div>
          <div class="col-md-2">
            <!-- LOGIN COMPONENT HERE -->
            <div class="user-icon">
              <Login />
            </div>
          </div>
        </div>
        <!-- Banner title and paragraphs -->
        <div class="banner-content text-center pb-2">
          <h1 class="All-Spice">Your Website Title</h1>
          <p class="text-MochaSlate">Your paragraph 1</p>
          <p class="text-MochaSlate">Your paragraph 2</p>
        </div>
      </div>

    </section>

    <!-- Navbar section -->
    <div class="container pt-2">
      <section class="row d-flex justify-content-center" style="margin-top: -40px;"> <!-- Adjust the margin-top value -->
        <div class="col-6">
          <Navbar class="shadow" />
        </div>
      </section>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style scoped lang="scss">
.shadow {
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  /* Adjust the values as needed */
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


/* Media query for screens below 600px */
@media screen and (max-width: 599px) {
  .bannerImg {
    background-image: url("src/assets/img/spoons.jpg");
  }
}
</style>
