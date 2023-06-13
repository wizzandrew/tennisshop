<template>
  <div class="carouselHolder">
    <div id="carouselIndicators" class="carousel slide" data-bs-ride="carousel">
      <div class="carousel-indicators">
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="0"
          class="active"
          aria-current="true"
          aria-label="Slide 1"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="1"
          aria-label="Slide 2"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="2"
          aria-label="Slide 3"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="3"
          aria-label="Slide 4"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="4"
          aria-label="Slide 5"
        ></button>
      </div>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img
            src="../img/carousel-img1.png"
            class="d-block w-100"
            alt="img1"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img2.png"
            class="d-block w-100"
            alt="img2"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img3.png"
            class="d-block w-100"
            alt="img3"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img4.png"
            class="d-block w-100"
            alt="img4"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img5.png"
            class="d-block w-100"
            alt="img5"
          />
        </div>
      </div>
      <button
        class="carousel-control-prev"
        type="button"
        data-bs-target="#carouselIndicators"
        data-bs-slide="prev"
      >
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button
        class="carousel-control-next"
        type="button"
        data-bs-target="#carouselIndicators"
        data-bs-slide="next"
      >
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
  </div>

  <div class="newArrivalsHolder">
    <h1>New Arrvials</h1>
    <br />
  </div>
  <div class="topSellersHolder">
    <h1>Top Sellers</h1>
    <br />
  </div>
</template>

<script setup>
import Counter from "../components/Counter.vue";
import { useCounterStore } from "../stores/counter";

// pinia
const store = useCounterStore();
</script>

<style lang="scss">
.carousel {
  .carousel-inner {
    img {
      height: 85.1875vh;
      width: 100%;
      object-fit: cover;
    }
  }
}
</style>
