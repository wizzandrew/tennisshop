<template>
  <div class="slider">
    <div
      class="my-slider"
      v-if="
        store.newArrivalItems !== undefined &&
        Array.isArray(store.newArrivalItems) &&
        store.newArrivalItems.length > 0
      "
    >
      <div class="slide" v-for="shopItem in store.newArrivalItems">
        <div class="card">
          <img v-bind:src="shopItem.img" class="card-img-top" alt="..." />
          <div class="card-body">
            <p class="card-text">
              <b>{{ shopItem.brand }}</b> {{ shopItem.name }}
            </p>
            <span v-if="shopItem.salePrice === 0"
              ><b>€ {{ shopItem.price }}</b></span
            >
            <span v-else
              ><b>€ {{ shopItem.price }}</b>
              <del>€ {{ shopItem.salePrice }}</del></span
            >
          </div>
        </div>
      </div>
    </div>

    <div id="controls">
      <button class="previous">
        <img src="../img/angle-left.svg" alt="&lt" />
      </button>
      <button class="next"><img src="../img/angle-right.svg" alt=">" /></button>
    </div>
  </div>
</template>

<script setup>
import { tns } from "tiny-slider/src/tiny-slider";
import { onMounted, onUpdated } from "vue";
import { shopStore } from "../stores/shop";

const store = shopStore();

let slider;

onMounted(() => {
  // check if all slides for new arrivals were loaded
  // there should be 7 slides
  // but it finds 8 elements with class "slide" - bug
  let slides = document.getElementsByClassName("slide");

  if (slides.length === 8) {
    slider = tns({
      container: ".my-slider",
      items: 4,
      gutter: 5,
      slideBy: 2,
      speed: 400,
      nav: false,
      controlsContainer: "#controls",
      prevButton: ".previous",
      nextButton: ".next",
      responsive: {
        769: {
          items: 4,
        },
        768: {
          items: 3,
        },
      },
    });
  }
});

onUpdated(() => {
  // check if all slides for new arrivals were loaded
  // there should be 7 slides
  // but it finds 8 elements with class "slide" - bug
  let _slides = document.getElementsByClassName("slide");

  if (_slides.length === 8) {
    slider = tns({
      container: ".my-slider",
      items: 4,
      gutter: 5,
      slideBy: 2,
      speed: 400,
      nav: false,
      controlsContainer: "#controls",
      prevButton: ".previous",
      nextButton: ".next",
      responsive: {
        769: {
          items: 4,
        },
        768: {
          items: 3,
        },
      },
    });
  }
});
</script>

<style lang="scss">
.my-slider {
  .slide {
    padding: 10px;
    .card {
      display: flex;
      justify-content: center;
      align-items: center;

      .card-body {
        text-align: center;

        .card-text {
          min-height: 48px;
        }

        del {
          padding-left: 20px;
        }
      }
    }
  }
}

#controls {
  position: relative;

  .previous,
  .next {
    position: absolute;
    top: -217px;
    bottom: 188px;
    z-index: 1;
    display: flex;
    background-color: white;
    border: none;
    padding: 0;
  }

  .previous {
    left: -44px;
  }

  .next {
    right: -50px;
  }

  .previous img,
  .next img {
    width: 48px;
    height: auto;
  }
}
</style>
