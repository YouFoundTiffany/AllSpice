<template>
    <div class="card mb-2 square-card">
        <div class="card-img-wrapper">
            <img class="img-fluid" :src="recipe.Img" alt="">
            <!-- Heart icon for favorites -->
            <i class="mdi mdi-heart text-danger" v-if="recipe.favorite"></i>
        </div>
        <div class="card-body">
            <!-- Category pill shape with blur background -->
            <div class="category-pill">
                <span>{{ recipe.category }}</span>
            </div>
            <!-- Blurred title at the bottom of the card -->
            <h3 class="card-title text-UltraDrkNutmeg">
                <span class="blurred-text">{{ recipe.title }}</span>
            </h3>
            <!-- Button to view more details -->
            <button class="btn btn-warning w-100" data-bs-toggle="modal" data-bs-target="#projectModal"
                @click="addToFavorites()">
                See Project
            </button>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        recipe: Object,
    },
    setup(props) {
        const addToFavorites = () => {
            // Implement your addToFavorites logic here
        };

        return {
            addToFavorites,
        };
    },
};
</script>

<style scoped>
.square-card {
    width: 200px;
    /* Adjust the card width as needed */
}

.card-img-wrapper {
    position: relative;
    overflow: hidden;
}

.mdi-heart {
    position: absolute;
    top: 10px;
    right: 10px;
    font-size: 24px;
}

.category-pill {
    position: absolute;
    top: 10px;
    left: 10px;
    background-color: rgba(0, 0, 0, 0.7);
    /* Adjust the background color and opacity */
    padding: 5px 10px;
    border-radius: 20px;
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
</style>
