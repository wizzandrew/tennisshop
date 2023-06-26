<template>
  <div class="container">
    <div class="row">
      <div class="col-3">
        <FilterItems @filter-rackets="manageFiltering" />
      </div>
      <div class="col-9">
        <div class="racketsImageBanner">
          <div class="col">
            <img src="../img/rackets-banner.jpg" alt="racket" />
          </div>
        </div>
        <div class="racketsHeading">
          <div class="col-6">
            <h3>Tennis rackets</h3>
          </div>
        </div>
        <div class="racketsInfoSorting">
          <div class="row">
            <div class="col-6 racketsInfo">
              {{ currentRackets?.length }} Results
            </div>
            <div class="col-6 racketsSorting">
              <span><b>Sort by:</b></span>
              <div>
                <SortDropdown @select="manageSorting" />
              </div>
            </div>
          </div>
        </div>
        <div class="racketsWrapper">
          <div
            class="col"
            v-if="currentRackets !== null && Array.isArray(currentRackets)"
          >
            <div class="row">
              <div class="col-6 racket" v-for="racket in currentRackets">
                <div class="col-5">
                  <img v-bind:src="racket.img" alt="racket" />
                </div>
                <div class="col-7">
                  <p>
                    <b>{{ racket.brand }}</b> {{ racket.name }}
                  </p>
                  <div class="racketPrice">
                    <span v-if="racket.salePrice === 0"
                      ><b>€ {{ racket.price }}</b></span
                    >
                    <span v-else
                      ><del>€ {{ racket.price }}</del> <br />
                      <b>€ {{ racket.salePrice }}</b></span
                    >
                  </div>
                  <div class="racketRating" v-if="racket.popular">
                    <div class="ratingWrapper">
                      <span
                        v-for="index in Math.floor(racket.rating)"
                        style="color: #ffed00"
                        >★</span
                      >
                      <span v-for="index in 5 - Math.floor(racket.rating)"
                        >★</span
                      >
                    </div>
                    <p>Rating {{ racket.rating }}</p>
                  </div>
                  <hr />
                  <div class="racketFeatures">
                    <div class="racketHead">
                      <img src="../img/racket-icon2.png" />
                      <span>{{ racket.headSize }}cm<sup>2</sup></span>
                    </div>
                    <div class="racketGrip">
                      <img src="../img/grip-icon.png" />
                      <span>{{ racket.gripSize }}</span>
                    </div>
                    <div class="racketWeight">
                      <img src="../img/weight-icon.png" />
                      <span>{{ racket.weight }}g</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<!-- eslint-disable vue/no-use-v-if-with-v-for,vue/no-confusing-v-for-v-if -->

<script setup>
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";
import SortDropdown from "../components/SortDropdown.vue";
import FilterItems from "../components/FilterRacketItems.vue";
import { onMounted, onUpdated, computed, ref } from "vue";

const store = shopStore();

// initial rackets retrieved from db
const { racketItems } = storeToRefs(store);

// current rackets to dynamicly provide rackets on the page
const currentRackets = ref(racketItems.value);

// sorts rackets by rating
const mostPopularRackets = computed(() => {
  const popular = currentRackets.value;
  popular.sort((a, b) => b.rating - a.rating);
  return popular;
});

// sorts rackets by price ascending
const lowtoHighPriceRackets = computed(() => {
  const lowToHigh = currentRackets.value;
  lowToHigh.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return aPrice - bPrice;
  });
  return lowToHigh;
});

// sorts rackets by price descending
const highToLowPriceRackets = computed(() => {
  const highToLow = currentRackets.value;
  highToLow.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return bPrice - aPrice;
  });
  return highToLow;
});

const setCurrentRackets = (current) => {
  currentRackets.value = current;
};

// handles racket sorting
const manageSorting = (sorting) => {
  if (sorting === "Most popular") {
    setCurrentRackets(mostPopularRackets.value);
  } else if (sorting === "Price low-to-high") {
    setCurrentRackets(lowtoHighPriceRackets.value);
  } else if (sorting === "Price high-to-low") {
    setCurrentRackets(highToLowPriceRackets.value);
  }
};

// manages racket filtering by brand, price range, weight, headsize, gripsize
const manageFiltering = (args) => {
  //set current rackets to default before filtering
  setCurrentRackets(racketItems.value);

  // brands
  if (
    currentRackets.value !== undefined &&
    Array.isArray(currentRackets.value)
  ) {
    args.brands.forEach((element) => {
      if (element.value) {
        const filtered = currentRackets.value.filter(
          (r) => r.brand === element.name
        );
        setCurrentRackets(filtered);
      }
    });
  }

  // prices
  if (
    currentRackets.value !== undefined &&
    Array.isArray(currentRackets.value)
  ) {
    const filtered = currentRackets.value.filter((r) => {
      const racketPrice = r.salePrice === 0 ? r.price : r.salePrice;
      return (
        racketPrice >= args.prices[0].min && racketPrice <= args.prices[0].max
      );
    });
    setCurrentRackets(filtered);
  }

  // weight
  if (
    currentRackets.value !== undefined &&
    Array.isArray(currentRackets.value)
  ) {
    args.weights.forEach((element) => {
      if (element.value) {
        const filtered = currentRackets.value.filter(
          (r) =>
            Number(r.weight) >= Number(element.min) &&
            Number(r.weight) <= Number(element.max)
        );
        setCurrentRackets(filtered);
      }
    });
  }

  // head sizes
  if (
    currentRackets.value !== undefined &&
    Array.isArray(currentRackets.value)
  ) {
    args.headSizes.forEach((element) => {
      if (element.value) {
        const filtered = currentRackets.value.filter(
          (r) =>
            Number(r.headSize) >= Number(element.min) &&
            Number(r.headSize) <= Number(element.max)
        );
        setCurrentRackets(filtered);
      }
    });
  }

  // grip sizes
  if (
    currentRackets.value !== undefined &&
    Array.isArray(currentRackets.value)
  ) {
    args.gripSizes.forEach((element) => {
      if (element.value) {
        const filtered = currentRackets.value.filter(
          (r) => r.gripSize === element.grip
        );
        setCurrentRackets(filtered);
      }
    });
  }
};
</script>

<style lang="scss">
@import "../assets/sass";

.racketsImageBanner {
  padding: 45px 0 30px 0;

  img {
    height: 130px;
    width: 100%;
    object-fit: cover;
  }
}

.racketsHeading {
  padding-bottom: 40px;
  h3 {
    font-weight: 600;
    color: #424242;
  }
}

.racketsInfoSorting {
  .racketsInfo,
  .racketsSorting {
    font-size: 14px;
  }

  .racketsSorting {
    @include displayFlex(row);
    justify-content: flex-end;

    div {
      padding-left: 30px;
    }
  }
}

.racketsWrapper {
  padding-top: 50px;

  .racket {
    margin-bottom: 20px;
    display: flex;
    border: 1px solid grey;

    img {
      width: 100%;
      height: auto;
    }

    .racketFeatures {
      @include displayFlex(row);
      img {
        height: 28px;
        width: 28px;
      }
    }
  }
}
</style>
