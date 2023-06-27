<template>
  <div class="filterWrapper">
    <div class="row">
      <div class="col">
        <h6>Tennis accessories</h6>
        <hr />
        <div class="typeFilter">
          <ul class="list-group types-list">
            <li
              class="list-group-item types-list-item"
              v-for="_type in accessoryTypes"
            >
              <label
                class="form-check-label stretched-link"
                @click="manageAccessoryType(_type)"
                >{{ _type }}</label
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Brand</h6>
        <hr />
        <div class="brandFilter">
          <ul class="list-group brands-list">
            <li
              class="list-group-item brands-list-item"
              v-for="brand in brandState"
            >
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brand.value"
                v-bind:id="dynamicAttr(brand.name, 'Checkbox')"
                @change="accessoriesFilter"
              />
              <label
                class="form-check-label stretched-link"
                v-bind:for="dynamicAttr(brand.name, 'Checkbox')"
                >{{ brand.name }}</label
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Price €</h6>
        <div class="priceInputs">
          <div class="price-content">
            <input
              type="number"
              v-model="leftPriceSlider"
              @change="validateRange"
            />
            <span>-</span>
            <input
              type="number"
              v-model="rightPriceSlider"
              @change="validateRange"
            />
          </div>

          <div class="range-slider">
            <input
              type="range"
              class="min-price"
              v-model="leftPriceSlider"
              min="5"
              max="299"
              @change="validateRange"
            />
            <input
              type="range"
              class="max-price"
              v-model="rightPriceSlider"
              min="6"
              max="300"
              @change="validateRange"
            />
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Size</h6>
        <hr />
        <div class="sizeFilter">
          <ul class="list-group sizes-list">
            <li
              class="list-group-item sizes-list-item"
              v-for="size in sizeState"
            >
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="size.value"
                v-bind:id="dynamicAttr(size.name, 'Checkbox')"
                @change="accessoriesFilter"
              />
              <label
                class="form-check-label stretched-link"
                v-bind:for="dynamicAttr(size.name, 'Checkbox')"
                >{{ size.name }}</label
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Colour</h6>
        <hr />
        <div class="colourFilter">
          <ul class="list-group colours-list">
            <li
              class="list-group-item colours-list-item"
              v-for="colour in colourState"
            >
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colour.value"
                v-bind:id="dynamicAttr(colour.name, 'Checkbox')"
                @change="accessoriesFilter"
              />
              <label
                class="form-check-label stretched-link"
                v-bind:for="dynamicAttr(colour.name, 'Checkbox')"
                >{{ colour.name }}</label
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
const accessoryTypes = ["Bag", "Balls", "Strings"];
const currentAccessoryType = ref("");

const brandState = ref([
  { name: "Dunlop", value: false },
  { name: "HEAD", value: false },
  { name: "Tecnifibre", value: false },
  { name: "Wilson", value: false },
  { name: "Yonex", value: false },
]);

const sizeState = ref([
  { name: "Standard", value: false },
  { name: "1.20", value: false },
  { name: "1.25", value: false },
  { name: "1.30", value: false },
]);

const colourState = ref([
  { name: "Black", value: false },
  { name: "Blue", value: false },
  { name: "White", value: false },
  { name: "Grey", value: false },
  { name: "Red", value: false },
  { name: "Green", value: false },
  { name: "Yellow", value: false },
]);

const leftPriceSlider = ref(5);
const rightPriceSlider = ref(300);

const clothingsFilterEmit = defineEmits("filter-accessories");

// function constructs filter object and emits it to parent(ClothingVue)
const accessoriesFilter = () => {
  // arrays to hold filter state and checkbox value
  const accessoryType = [];
  const brandsToFilter = [];
  const pricesToFilter = [];
  const sizesToFilter = [];
  const coloursToFilter = [];

  // accessory type
  accessoryType.push({
    name: currentAccessoryType.value,
  });

  // brands
  brandState.value.forEach((element) => {
    brandsToFilter.push(element);
  });

  // price
  pricesToFilter.push({
    min: leftPriceSlider.value,
    max: rightPriceSlider.value,
  });

  // size
  sizeState.value.forEach((element) => {
    sizesToFilter.push(element);
  });

  // colour
  colourState.value.forEach((element) => {
    coloursToFilter.push(element);
  });

  // construct filter object
  const filterObject = {
    type: accessoryType,
    brands: brandsToFilter,
    prices: pricesToFilter,
    sizes: sizesToFilter,
    colours: coloursToFilter,
  };

  clothingsFilterEmit("filter-accessories", filterObject);
};

// manage accessory type selection
const manageAccessoryType = (type) => {
  currentAccessoryType.value = type;
  accessoriesFilter();
};

// make sure left price doesnt become bigger than right price
// e.g user grags left price across right price
const validateRange = () => {
  if (Number(leftPriceSlider.value) > Number(rightPriceSlider.value)) {
    leftPriceSlider.value = 10;
    rightPriceSlider.value = 150;
  }

  // call clothingsFilter() to proceed to emit
  accessoriesFilter();
};

// gives dynamic id for <input>
const dynamicAttr = (property, string) => {
  return property + "accessory" + string;
};
</script>

<style lang="scss">
@import "../assets//sass";

.filterWrapper {
  padding-top: 219px;

  .priceInputs {
    width: 100%;
    .price-content {
      @include displayFlex(row);
      align-items: center;

      input {
        width: 70px;
      }
    }

    .range-slider {
      width: auto;
      position: relative;
      margin: 15px 0 30px 0;

      input[type="range"] {
        appearance: none;
        width: 100%;
        background: transparent;
        position: absolute;
        left: 0;
      }

      input[type="range"]::-webkit-slider-thumb {
        appearance: none;
        height: 15px;
        width: 15px;
        border-radius: 50%;
        background: white;
        cursor: pointer;
        margin-top: -5px;
        position: relative;
        z-index: 1;
      }

      input[type="range"]::-webkit-slider-runnable-track {
        width: 100%;
        height: 5px;
        background: $theYellow;
        border-radius: 3px;
        border: none;
      }
    }
  }
}
</style>
