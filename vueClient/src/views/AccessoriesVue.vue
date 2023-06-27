<template>
  <div class="container">
    <div class="row">
      <div class="col-3">
        <FilterItems @filter-accessories="manageFiltering" />
      </div>
      <div class="col-9">
        <div class="accessoriesImageBanner">
          <div class="col">
            <img src="../img/rackets-banner.jpg" alt="racket" />
          </div>
        </div>
        <div class="accessoriesHeading">
          <div class="col-6">
            <h3>Tennis accessories</h3>
          </div>
        </div>
        <div class="accessoriesInfoSorting">
          <div class="row">
            <div class="col-6 accessoriesInfo">
              {{ currentAccessories?.length }} Results
            </div>
            <div class="col-6 accessoriesSorting">
              <span><b>Sort by:</b></span>
              <div><SortDropdown @select="manageSorting" /></div>
            </div>
          </div>
        </div>
        <div class="accessoriesWrapper">
          <div
            class="col"
            v-if="
              currentAccessories !== null && Array.isArray(currentAccessories)
            "
          >
            <div class="row">
              <div
                class="col-6 col-md-3 accessory"
                v-for="accessory in currentAccessories"
              >
                <div class="card">
                  <img
                    v-bind:src="accessory.img"
                    class="card-img-top"
                    alt="clothing"
                  />
                  <div class="card-body">
                    <p class="card-text">
                      <b>{{ accessory.brand }}</b> {{ accessory.name }}
                    </p>
                    <div class="clothingPrice">
                      <span v-if="accessory.salePrice === 0"
                        ><b>€ {{ accessory.price }}</b></span
                      >
                      <span v-else
                        ><del>€ {{ accessory.price }}</del> <br />
                        <b>€ {{ accessory.salePrice }}</b></span
                      >
                    </div>
                    <div class="accessoryRating" v-if="accessory.rating">
                      <div class="ratingWrapper">
                        <span
                          v-for="index in Math.floor(accessory.rating)"
                          style="color: #ffed00"
                          >★</span
                        >
                        <span v-for="index in 5 - Math.floor(accessory.rating)"
                          >★</span
                        >
                        <span>{{ accessory.rating }}</span>
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
  </div>
</template>

<script setup>
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";
import { computed, ref } from "vue";
import SortDropdown from "../components/SortDropdown.vue";
import FilterItems from "../components/FilterAccessoriesItems.vue";

const store = shopStore();

// initial accessories retrieved from db
const { accessoryItems } = storeToRefs(store);

// current accessories to dynamicly provide clothes on the page
const currentAccessories = ref(accessoryItems.value);

// sorts accessories by rating
const mostPopularAccessories = computed(() => {
  const popular = currentAccessories.value;
  popular.sort((a, b) => b.rating - a.rating);
  return popular;
});

// sorts accessories by price ascending
const lowtoHighPriceAccessories = computed(() => {
  const lowToHigh = currentAccessories.value;
  lowToHigh.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return aPrice - bPrice;
  });
  return lowToHigh;
});

// sorts accessories by price descending
const highToLowPriceAccessories = computed(() => {
  const highToLow = currentAccessories.value;
  highToLow.sort((a, b) => {
    const aPrice = a.salePrice === 0 ? a.price : a.salePrice;
    const bPrice = b.salePrice === 0 ? b.price : b.salePrice;
    return bPrice - aPrice;
  });
  return highToLow;
});

const setCurrentAccessories = (current) => {
  currentAccessories.value = current;
};

// handles accessories sorting
const manageSorting = (sorting) => {
  if (sorting === "Most popular") {
    setCurrentAccessories(mostPopularAccessories.value);
  } else if (sorting === "Price low-to-high") {
    setCurrentAccessories(lowtoHighPriceAccessories.value);
  } else if (sorting === "Price high-to-low") {
    setCurrentAccessories(highToLowPriceAccessories.value);
  }
};

// manages accessories filtering by type, brand, price range, color
const manageFiltering = (args) => {
  //set current clothings to default before filtering
  setCurrentAccessories(accessoryItems.value);

  // accessories type
  if (
    currentAccessories.value !== undefined &&
    Array.isArray(currentAccessories.value)
  ) {
    if (args.type[0].name.length > 0) {
      const filtered = currentAccessories.value.filter(
        (a) => a.type === args.type[0].name
      );
      setCurrentAccessories(filtered);
    }
  }

  // brands
  if (
    currentAccessories.value !== undefined &&
    Array.isArray(currentAccessories.value)
  ) {
    args.brands.forEach((element) => {
      if (element.value) {
        const filtered = currentAccessories.value.filter((a) => {
          return a.brand === element.name;
        });
        setCurrentAccessories(filtered);
      }
    });
  }

  // prices;
  if (
    currentAccessories.value !== undefined &&
    Array.isArray(currentAccessories.value)
  ) {
    const filtered = currentAccessories.value.filter((a) => {
      const accessoryPrice = a.salePrice === 0 ? a.price : a.salePrice;
      return (
        accessoryPrice >= args.prices[0].min &&
        accessoryPrice <= args.prices[0].max
      );
    });
    setCurrentAccessories(filtered);
  }

  // size
  if (
    currentAccessories.value !== undefined &&
    Array.isArray(currentAccessories.value)
  ) {
    args.sizes.forEach((element) => {
      if (element.value) {
        const filtered = currentAccessories.value.filter(
          (a) => a.size === element.name
        );
        setCurrentAccessories(filtered);
      }
    });
  }

  // colours
  if (
    currentAccessories.value !== undefined &&
    Array.isArray(currentAccessories.value)
  ) {
    args.colours.forEach((element) => {
      if (element.value) {
        const filtered = currentAccessories.value.filter(
          (a) => a.color === element.name
        );
        setCurrentAccessories(filtered);
      }
    });
  }
};
</script>

<style lang="scss">
@import "../assets/sass";

.accessoriesImageBanner {
  padding: 45px 0 30px 0;

  img {
    height: 130px;
    width: 100%;
    object-fit: cover;
  }
}

.accessoriesHeading {
  padding-bottom: 40px;
  h3 {
    font-weight: 600;
    color: #424242;
  }
}

.accessoriesInfoSorting {
  .accessoriesInfo,
  .accessoriesSorting {
    font-size: 14px;
  }

  .accessoriesSorting {
    @include displayFlex(row);
    justify-content: flex-end;

    div {
      padding-left: 30px;
    }
  }
}

.accessoriesWrapper {
  padding-top: 50px;

  .accessory {
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
