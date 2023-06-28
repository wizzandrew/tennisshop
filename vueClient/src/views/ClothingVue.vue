<template>
  <div class="container">
    <div class="row">
      <div class="col-3">
        <FilterItems @filter-clothings="manageFiltering" />
      </div>
      <div class="col-9">
        <div class="clothingsImageBanner">
          <div class="col">
            <img src="../img/rackets-banner.jpg" alt="racket" />
          </div>
        </div>
        <div class="clothingsHeading">
          <div class="col-6">
            <h3>Tennis clothing</h3>
          </div>
        </div>
        <div class="clothingsInfoSorting">
          <div class="row">
            <div class="col-6 clothingsInfo">
              {{ currentClothings?.length }} Results
            </div>
            <div class="col-6 clothingsSorting">
              <span><b>Sort by:</b></span>
              <div><SortDropdown @select="manageSorting" /></div>
            </div>
          </div>
        </div>
        <div class="clothingsWrapper">
          <div
            class="col"
            v-if="currentClothings !== null && Array.isArray(currentClothings)"
          >
            <div class="row">
              <div
                class="col-6 col-md-3 clothing"
                v-for="clothing in currentClothings"
              >
                <router-link
                  :to="getClothingLink(clothing.id)"
                  style="color: black; text-decoration: none"
                >
                  <div class="card">
                    <img
                      v-bind:src="clothing.img"
                      class="card-img-top"
                      alt="clothing"
                    />
                    <div class="card-body">
                      <p class="card-text">
                        <b>{{ clothing.brand }}</b> {{ clothing.name }}
                      </p>
                      <div class="clothingPrice">
                        <span v-if="clothing.salePrice === 0"
                          ><b>€ {{ clothing.price }}</b></span
                        >
                        <span v-else
                          ><del>€ {{ clothing.price }}</del> <br />
                          <b>€ {{ clothing.salePrice }}</b></span
                        >
                      </div>
                      <div class="clothingRating" v-if="clothing.rating">
                        <div class="ratingWrapper">
                          <span
                            v-for="index in Math.floor(clothing.rating)"
                            style="color: #ffed00"
                            >★</span
                          >
                          <span v-for="index in 5 - Math.floor(clothing.rating)"
                            >★</span
                          >
                          <span>{{ clothing.rating }}</span>
                        </div>
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

<script setup>
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";
import { computed, ref } from "vue";
import SortDropdown from "../components/SortDropdown.vue";
import FilterItems from "../components/FilterClothingItems.vue";

const store = shopStore();

// initial clothings retrieved from db
const { clothingItems } = storeToRefs(store);

// current clothings to dynamicly provide clothes on the page
const currentClothings = ref(clothingItems.value);

// sorts clothings by rating
const mostPopularClothings = computed(() => {
  const popular = currentClothings.value;
  popular.sort((a, b) => b.rating - a.rating);
  return popular;
});

// sorts clothings by price ascending
const lowtoHighPriceClothings = computed(() => {
  const lowToHigh = currentClothings.value;
  lowToHigh.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return aPrice - bPrice;
  });
  return lowToHigh;
});

// sorts clothings by price descending
const highToLowPriceClothings = computed(() => {
  const highToLow = currentClothings.value;
  highToLow.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return bPrice - aPrice;
  });
  return highToLow;
});

// creates link for single clothing
const getClothingLink = (id) => {
  return `/clothing/${id}`;
};

const setCurrentClothings = (current) => {
  currentClothings.value = current;
};

// handles clothings sorting
const manageSorting = (sorting) => {
  if (sorting === "Most popular") {
    setCurrentClothings(mostPopularClothings.value);
  } else if (sorting === "Price low-to-high") {
    setCurrentClothings(lowtoHighPriceClothings.value);
  } else if (sorting === "Price high-to-low") {
    setCurrentClothings(highToLowPriceClothings.value);
  }
};

// manages clothing filtering by type, brand, price range, gender, color, size
const manageFiltering = (args) => {
  //set current clothings to default before filtering
  setCurrentClothings(clothingItems.value);

  // clothing type
  if (
    currentClothings.value !== undefined &&
    Array.isArray(currentClothings.value)
  ) {
    if (args.type[0].name.length > 0) {
      const filtered = currentClothings.value.filter(
        (c) => c.type === args.type[0].name
      );
      setCurrentClothings(filtered);
    }
  }

  // brands
  if (
    currentClothings.value !== undefined &&
    Array.isArray(currentClothings.value)
  ) {
    args.brands.forEach((element) => {
      if (element.value) {
        const filtered = currentClothings.value.filter(
          (c) => c.brand === element.name
        );
        setCurrentClothings(filtered);
      }
    });
  }

  // prices;
  if (
    currentClothings.value !== undefined &&
    Array.isArray(currentClothings.value)
  ) {
    const filtered = currentClothings.value.filter((c) => {
      const clothingPrice = c.salePrice === 0 ? c.price : c.salePrice;
      return (
        clothingPrice >= args.prices[0].min &&
        clothingPrice <= args.prices[0].max
      );
    });
    setCurrentClothings(filtered);
  }

  // genders
  if (
    currentClothings.value !== undefined &&
    Array.isArray(currentClothings.value)
  ) {
    // target the case when both male and female inputs are set to true
    // should return nothing, cause there are no unisex clothings
    if (args.genders[0].male && args.genders[0].female) {
      setCurrentClothings([]);
    }
    // target the case when either male or female inputs are set to true
    else if (args.genders[0].male || args.genders[0].female) {
      const filtered = currentClothings.value.filter((c) => {
        if (args.genders[0].male) {
          return c.gender;
        } else if (args.genders[0].female) {
          return !c.gender;
        }
      });

      setCurrentClothings(filtered);
    }
  }

  // size
  if (
    currentClothings.value !== undefined &&
    Array.isArray(currentClothings.value)
  ) {
    args.sizes.forEach((element) => {
      if (element.value) {
        const filtered = currentClothings.value.filter(
          (c) => c.size === element.name
        );
        setCurrentClothings(filtered);
      }
    });
  }

  // colours
  if (
    currentClothings.value !== undefined &&
    Array.isArray(currentClothings.value)
  ) {
    args.colours.forEach((element) => {
      if (element.value) {
        const filtered = currentClothings.value.filter(
          (c) => c.color === element.name
        );
        setCurrentClothings(filtered);
      }
    });
  }
};
</script>

<style lang="scss">
@import "../assets/sass";

.clothingsImageBanner {
  padding: 45px 0 30px 0;

  img {
    height: 130px;
    width: 100%;
    object-fit: cover;
  }
}

.clothingsHeading {
  padding-bottom: 40px;
  h3 {
    font-weight: 600;
    color: #424242;
  }
}

.clothingsInfoSorting {
  .clothingsInfo,
  .clothingsSorting {
    font-size: 14px;
  }

  .clothingsSorting {
    @include displayFlex(row);
    justify-content: flex-end;

    div {
      padding-left: 30px;
    }
  }
}

.clothingsWrapper {
  padding-top: 50px;

  .clothing {
    margin-bottom: 20px;
    @include displayFlex(row);

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
</style>
