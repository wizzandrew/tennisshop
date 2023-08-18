<template>
  <div class="container">
    <div class="row">
      <div class="col-3">
        <FilterItems @filter-shoes="manageFiltering" />
      </div>
      <div class="col-9">
        <div class="shoesImageBanner">
          <div class="col">
            <img src="../img/rackets-banner.jpg" alt="racket" />
          </div>
        </div>
        <div class="shoesHeading">
          <div class="col-6">
            <h3>Tennis shoes</h3>
          </div>
        </div>
        <div class="shoesInfoSorting">
          <div class="row">
            <div class="col-6 shoesInfo">
              {{ currentShoes?.length }} Results
            </div>
            <div class="col-6 shoesSorting">
              <span><b>Sort by:</b></span>
              <div><SortDropdown @select="manageSorting" /></div>
            </div>
          </div>
        </div>
        <div class="shoesWrapper">
          <div
            class="col"
            v-if="currentShoes !== null && Array.isArray(currentShoes)"
          >
            <div class="row">
              <div class="col-6 col-md-3 shoes" v-for="shoes in currentShoes">
                <router-link
                  :to="getShoesLink(shoes.id)"
                  style="color: black; text-decoration: none"
                >
                  <div class="card">
                    <img
                      v-bind:src="shoes.img"
                      class="card-img-top"
                      alt="clothing"
                    />
                    <div class="card-body">
                      <p class="card-text">
                        <b>{{ shoes.brand }}</b> <br />
                        {{ shoes.name }}
                      </p>
                      <div class="shoesPrice">
                        <span v-if="shoes.salePrice === 0"
                          ><b>€ {{ shoes.price }}</b></span
                        >
                        <span v-else>
                          <b>€ {{ shoes.salePrice }}</b>
                          <del>€ {{ shoes.price }}</del>
                        </span>
                      </div>
                      <div class="shoesRating" v-if="shoes.rating">
                        <div class="ratingWrapper">
                          <span
                            v-for="index in Math.floor(shoes.rating)"
                            style="color: #ffed00"
                            >★</span
                          >
                          <span v-for="index in 5 - Math.floor(shoes.rating)"
                            >★</span
                          >
                        </div>
                        <p>{{ shoes.rating }}</p>
                      </div>
                      <div class="shoesRating" v-else></div>
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

<script setup>
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";
import { computed, ref } from "vue";
import SortDropdown from "../components/SortDropdown.vue";
import FilterItems from "../components/FilterShoesItems.vue";

const store = shopStore();

// initial shoes retrieved from db
const { shoeItems } = storeToRefs(store);

// current clothings to dynamicly provide clothes on the page
const currentShoes = ref(shoeItems.value);

// sorts shoes by rating
const mostPopularShoes = computed(() => {
  const popular = currentShoes.value;
  popular.sort((a, b) => b.rating - a.rating);
  return popular;
});

// sorts shoes by price ascending
const lowtoHighPriceShoes = computed(() => {
  const lowToHigh = currentShoes.value;
  lowToHigh.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return aPrice - bPrice;
  });
  return lowToHigh;
});

// sorts shoes by price descending
const highToLowPriceShoes = computed(() => {
  const highToLow = currentShoes.value;
  highToLow.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return bPrice - aPrice;
  });
  return highToLow;
});

// creates link for single shoes
const getShoesLink = (id) => {
  return `/shoes/${id}`;
};

const setCurrentShoes = (current) => {
  currentShoes.value = current;
};

// handles shoes sorting
const manageSorting = (sorting) => {
  if (sorting === "Most popular") {
    setCurrentShoes(mostPopularShoes.value);
  } else if (sorting === "Price low-to-high") {
    setCurrentShoes(lowtoHighPriceShoes.value);
  } else if (sorting === "Price high-to-low") {
    setCurrentShoes(highToLowPriceShoes.value);
  }
};

// manages shoes filtering by brand, price range, gender, color, size
const manageFiltering = (args) => {
  //set current clothings to default before filtering
  setCurrentShoes(shoeItems.value);

  // brands
  if (currentShoes.value !== undefined && Array.isArray(currentShoes.value)) {
    args.brands.forEach((element) => {
      if (element.value) {
        const filtered = currentShoes.value.filter(
          (s) => s.brand === element.name
        );
        setCurrentShoes(filtered);
      }
    });
  }

  // prices
  if (currentShoes.value !== undefined && Array.isArray(currentShoes.value)) {
    const filtered = currentShoes.value.filter((s) => {
      const shoePrice = s.salePrice === 0 ? s.price : s.salePrice;
      return shoePrice >= args.prices[0].min && shoePrice <= args.prices[0].max;
    });
    setCurrentShoes(filtered);
  }

  // genders
  if (currentShoes.value !== undefined && Array.isArray(currentShoes.value)) {
    // target the case when both male and female inputs are set to true
    // should return nothing, cause there are no unisex clothings
    if (args.genders[0].male && args.genders[0].female) {
      setCurrentShoes([]);
    }
    // target the case when either male or female inputs are set to true
    else if (args.genders[0].male || args.genders[0].female) {
      const filtered = currentShoes.value.filter((c) => {
        if (args.genders[0].male) {
          return c.gender;
        } else if (args.genders[0].female) {
          return !c.gender;
        }
      });

      setCurrentShoes(filtered);
    }
  }

  // size
  if (currentShoes.value !== undefined && Array.isArray(currentShoes.value)) {
    args.sizes.forEach((element) => {
      if (element.value) {
        const filtered = currentShoes.value.filter(
          (s) => s.size === element.name
        );
        setCurrentShoes(filtered);
      }
    });
  }

  // colours
  if (currentShoes.value !== undefined && Array.isArray(currentShoes.value)) {
    args.colours.forEach((element) => {
      if (element.value) {
        const filtered = currentShoes.value.filter(
          (s) => s.color === element.name
        );
        setCurrentShoes(filtered);
      }
    });
  }
};
</script>

<style lang="scss">
@import "../assets/sass";

.shoesImageBanner {
  padding: 45px 0 30px 0;

  img {
    height: 130px;
    width: 100%;
    object-fit: cover;
  }
}

.shoesHeading {
  padding-bottom: 30px;
  h3 {
    font-weight: 600;
    color: #424242;
  }
}

.shoesInfoSorting {
  font-size: 14px;

  .row {
    align-items: center;
  }

  .shoesSorting {
    @include displayFlex(row);
    justify-content: flex-end;
    align-items: center;

    div {
      padding-left: 20px;
    }
  }
}

.shoesWrapper {
  padding-top: 30px;

  .shoes {
    margin-bottom: 20px;
    @include displayFlex(row);
    font-size: 14px;

    .card {
      display: flex;
      justify-content: center;
      align-items: center;

      .card-body {
        text-align: center;

        .card-text {
          min-height: 63px;
        }

        .shoesPrice {
          del {
            padding-left: 20px;
            color: grey;
          }
        }

        .shoesRating {
          @include displayFlex(row);
          align-items: center;
          justify-content: center;
          min-height: 36px;

          .ratingWrapper {
            span {
              font-size: 24px;
            }
          }

          p {
            display: inline-block;
            margin: 0;
            padding-top: 4px;
          }
        }
      }
    }
  }
}
</style>
