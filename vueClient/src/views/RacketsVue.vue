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
                <router-link
                  :to="getRacketLink(racket.id)"
                  style="color: black; text-decoration: none"
                >
                  <div class="col-5">
                    <img v-bind:src="racket.img" alt="racket" />
                  </div>
                  <div class="col-7">
                    <div class="racketName">
                      <p>
                        <b>{{ racket.brand }}</b> <br />{{ racket.name }}
                      </p>
                    </div>
                    <div class="racketPrice">
                      <span v-if="racket.salePrice === 0"
                        ><b>€ {{ racket.price }}</b></span
                      >
                      <span v-else
                        ><del>€ {{ racket.price }}</del> <br />
                        <b>€ {{ racket.salePrice }}</b></span
                      >
                    </div>
                    <div>
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
                        <p>{{ racket.rating }}</p>
                      </div>
                      <div class="racketRating" v-else></div>
                    </div>
                    <hr />
                    <div class="racketFeatures">
                      <div class="racketHead">
                        <img src="../img/racket-icon24.svg" />
                        <span>{{ racket.headSize }} cm<sup>2</sup></span>
                      </div>
                      <div class="racketGrip">
                        <img src="../img/grip-icon4.svg" />
                        <span>{{ racket.gripSize }}</span>
                      </div>
                      <div class="racketWeight">
                        <img src="../img/weight-icon4.svg" />
                        <span>{{ racket.weight }} g</span>
                      </div>
                    </div>
                  </div>
                </router-link>
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

// creates link for single racket
const getRacketLink = (id) => {
  return `/racket/${id}`;
};

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
  padding-bottom: 30px;
  h3 {
    font-weight: 600;
    color: #424242;
  }
}

.racketsInfoSorting {
  font-size: 14px;

  .row {
    align-items: center;
  }

  .racketsSorting {
    @include displayFlex(row);
    justify-content: flex-end;
    align-items: center;

    div {
      padding-left: 20px;
    }
  }
}

.racketsWrapper {
  padding-top: 30px;

  .row {
    width: 100%;
    margin: 0 auto;

    .racket {
      padding: 0;

      a {
        @include displayFlex(row);
        margin-bottom: 20px;
        padding: 40px 0;
        display: flex;
        border: 1px solid rgb(225, 225, 225);
        font-size: 14px;

        img {
          width: 100%;
          height: auto;
        }

        .racketName {
          width: 80%;

          p {
            min-height: 65px;
          }
        }

        .racketPrice {
          min-height: 42px;

          del {
            padding-left: 2.5px;
            font-size: 12px;
            color: grey;
          }
          margin-bottom: 7px;
        }

        .racketRating {
          @include displayFlex(row);
          align-items: center;
          min-height: 36px;

          .ratingWrapper {
            span {
              font-size: 24px;
            }
          }
          p {
            margin: 0;
            padding-top: 4px;
          }
        }

        hr {
          width: 68%;
          margin-bottom: 8px;
          color: #949494;
        }

        .racketFeatures {
          @include displayFlex(row);

          .racketHead,
          .racketGrip,
          .racketWeight {
            @include displayFlex(column);

            img {
              height: 32px;
              width: auto;
              margin: 0 auto;
            }

            span {
              color: #949494;
              padding-top: 2px;
            }
          }

          .racketGrip {
            padding: 0 20px;
            span {
              width: fit-content;
              margin: 0 auto;
            }
          }

          .racketWeight {
            padding: 0 5px;
          }
        }
      }
      &:nth-child(odd) {
        padding-right: 10px;
      }
    }
  }
}
</style>
