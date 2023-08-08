<template>
  <div class="filterWrapper">
    <div class="row">
      <div class="col">
        <h6>Tennis clothing</h6>
        <hr />
        <div class="typeFilter">
          <ul class="list-group types-list">
            <li
              class="list-group-item types-list-item"
              v-for="_type in clothingTypes"
            >
              <label
                class="form-check-label stretched-link"
                @click="manageClothingType(_type)"
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
                @change="clothingsFilter"
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
              min="10"
              max="149"
              @change="validateRange"
            />
            <input
              type="range"
              class="max-price"
              v-model="rightPriceSlider"
              min="11"
              max="150"
              @change="validateRange"
            />
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Gender</h6>
        <hr />
        <div class="genderFilter">
          <ul class="list-group gender-list">
            <li class="list-group-item gender-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="genderState.male"
                id="genderMalelCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="genderMalelCheckbox"
                >Men</label
              >
            </li>
            <li class="list-group-item gender-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="genderState.female"
                id="genderFemalelCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="genderFemalelCheckbox"
                >Women</label
              >
            </li>
          </ul>
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
                @change="clothingsFilter"
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
                @change="clothingsFilter"
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
const clothingTypes = ["Hoody", "Pants", "Dress", "Skirt", "Shirt", "Shorts"];
const currentClothingType = ref("");

const brandState = ref([
  { name: "Adidas", value: false },
  { name: "BIDI BADU", value: false },
  { name: "HEAD", value: false },
  { name: "Nike", value: false },
  { name: "Under Armour", value: false },
]);

const genderState = ref({
  male: false,
  female: false,
});

const sizeState = ref([
  { name: "S", value: false },
  { name: "M", value: false },
  { name: "L", value: false },
  { name: "XL", value: false },
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

const leftPriceSlider = ref(10);
const rightPriceSlider = ref(150);

const clothingsFilterEmit = defineEmits("filter-clothings");

// function constructs filter object and emits it to parent(ClothingVue)
const clothingsFilter = () => {
  // arrays to hold filter state and checkbox value
  const clothType = [];
  const brandsToFilter = [];
  const pricesToFilter = [];
  const gendersToFilter = [];
  const sizesToFilter = [];
  const coloursToFilter = [];

  // clothing type
  clothType.push({
    name: currentClothingType.value,
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

  // gender
  gendersToFilter.push({
    male: genderState.value.male,
    female: genderState.value.female,
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
    type: clothType,
    brands: brandsToFilter,
    prices: pricesToFilter,
    genders: gendersToFilter,
    sizes: sizesToFilter,
    colours: coloursToFilter,
  };

  clothingsFilterEmit("filter-clothings", filterObject);
};

// manage clothing type selection
const manageClothingType = (type) => {
  // patch
  // "Hoody" in db is set to "Hoodie"
  if (type == "Hoody") {
    currentClothingType.value = "Hoodie";
  } else {
    currentClothingType.value = type;
  }
  clothingsFilter();
};

// make sure left price doesnt become bigger than right price
// e.g user grags left price across right price
const validateRange = () => {
  if (Number(leftPriceSlider.value) > Number(rightPriceSlider.value)) {
    leftPriceSlider.value = 10;
    rightPriceSlider.value = 150;
  }

  // call clothingsFilter() to proceed to emit
  clothingsFilter();
};

// gives dynamic id for <input>
const dynamicAttr = (property, string) => {
  return property + "clothing" + string;
};
</script>

<style lang="scss">
@import "../assets//sass";

.filterWrapper {
  @include filterItems;

  .typeFilter {
    .list-group {
      .list-group-item {
        font-size: 15px;
        color: #222222;

        :hover {
          cursor: pointer;
          color: #000000;
          font-weight: 600;
        }
      }
    }
  }
}
</style>
