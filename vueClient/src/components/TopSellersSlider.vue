<template>
  <div class="slider">
    <div
      class="my-slider-sellers"
      v-if="
        topSellersItems !== undefined &&
        Array.isArray(topSellersItems) &&
        topSellersItems.length > 0
      "
    >
      <div class="slide-sellers" v-for="shopItem in topSellersItems">
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
              ><b>€ {{ shopItem.salePrice }}</b>
              <del>€ {{ shopItem.price }}</del></span
            >
          </div>
        </div>
      </div>
    </div>

    <div id="controls-sellers">
      <button class="previous-seller">
        <img src="../img/angle-left.svg" alt="&lt" />
      </button>
      <button class="next-seller">
        <img src="../img/angle-right.svg" alt=">" />
      </button>
    </div>
  </div>
</template>

<script setup>
import { tns } from "tiny-slider/src/tiny-slider";
import { onMounted, onUpdated } from "vue";
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";

const store = shopStore();
const { topSellersItems } = storeToRefs(store);

onMounted(() => {
  // check if all slides for new arrivals were loaded
  // there should be 8 slides
  let slides = document.getElementsByClassName("slide-sellers");

  if (slides.length === 8) {
    let slider = tns({
      container: ".my-slider-sellers",
      items: 4,
      gutter: 5,
      slideBy: 2,
      speed: 400,
      nav: false,
      controlsContainer: "#controls-sellers",
      prevButton: ".previous-seller",
      nextButton: ".next-seller",
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
  // there should be 8 slides
  let _slides = document.getElementsByClassName("slide-sellers");

  if (_slides.length === 8) {
    let slider = tns({
      container: ".my-slider-sellers",
      items: 4,
      gutter: 5,
      slideBy: 2,
      speed: 400,
      nav: false,
      controlsContainer: "#controls-sellers",
      prevButton: ".previous-seller",
      nextButton: ".next-seller",
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
.my-slider-sellers {
  .slide-sellers {
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

#controls-sellers {
  position: relative;

  .previous-seller,
  .next-seller {
    position: absolute;
    top: -217px;
    bottom: 188px;
    z-index: 1;
    display: flex;
    background-color: white;
    border: none;
    padding: 0;
  }

  .previous-seller {
    left: -44px;
  }

  .next-seller {
    right: -50px;
  }

  .previous-seller img,
  .next-seller img {
    width: 48px;
    height: auto;
  }
}
</style>
