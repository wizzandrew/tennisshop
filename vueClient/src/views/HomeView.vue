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

  <div class="container">
    <div class="newArrivalsHeading">
      <h2><span>NEW ARRIVALS</span></h2>
    </div>
  </div>

  <div class="underLine"></div>

  <div class="container">
    <NewArrivalsSlider />
  </div>

  <div class="container">
    <div class="topSellersHeading">
      <h2><span>TOP SELLERS</span></h2>
    </div>
  </div>

  <div class="underLine"></div>

  <div class="container">
    <TopSellersSlider />
  </div>
</template>

<script setup>
import { ref, computed, onMounted, onUpdated } from "vue";
import { storeToRefs } from "pinia";
import { shopStore } from "../stores/shop";
import * as api from "../shared/api.mjs";
import NewArrivalsSlider from "../components/NewArrivalsSlider.vue";
import TopSellersSlider from "../components/TopSellersSlider.vue";

// pinia
const store = shopStore();

//onMounted
onMounted(async () => {
  try {
    const arrivals = await api.getNewArrivals();
    if (arrivals !== undefined && arrivals !== null) {
      store.setNewArrivals(arrivals);
      console.log("new arrivals ", arrivals);
    }
  } catch (error) {
    console.log(error);
  }

  try {
    const sellers = await api.getTopSellers();
    if (sellers !== undefined && sellers !== null) {
      store.setTopSellers(sellers);
      console.log("top sellers ", sellers);
    }
  } catch (error) {
    console.log(error);
  }

  // console.log("home mounted", newArrivalItems);
});

// onUpdated(() => {
//   console.log("home updated", newArrivalItems);
// });
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

.newArrivalsHeading {
  padding-top: 75px;

  h2 {
    font-weight: 600;
    font-size: 1.8rem;
    letter-spacing: 2px;
    margin: 0;

    span {
      border-bottom: 3px solid #cf102d;
    }
  }
}

.underLine {
  border-bottom: 3px solid #eee;
  margin-bottom: 30px;
}

.topSellersHeading {
  padding-top: 100px;

  h2 {
    font-weight: 600;
    font-size: 1.8rem;
    letter-spacing: 2px;
    margin: 0;

    span {
      border-bottom: 3px solid #ffed00;
    }
  }
}
</style>
