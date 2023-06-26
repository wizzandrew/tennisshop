<template>
  <div class="filterWrapper">
    <div class="row">
      <div class="col">
        <h6>Tennis clothing</h6>
        <hr />
        <div class="typeFilter">
          <ul class="list-group types-list">
            <li class="list-group-item types-list-item">
              <label
                class="form-check-label stretched-link"
                @click="manageClothingType(clothingTypes[0])"
                >{{ clothingTypes[0] }}</label
              >
            </li>
            <li class="list-group-item types-list-item">
              <label
                class="form-check-label stretched-link"
                @click="manageClothingType(clothingTypes[1])"
                >{{ clothingTypes[1] }}</label
              >
            </li>
            <li class="list-group-item types-list-item">
              <label
                class="form-check-label stretched-link"
                @click="manageClothingType(clothingTypes[2])"
                >{{ clothingTypes[2] }}</label
              >
            </li>
            <li class="list-group-item types-list-item">
              <label
                class="form-check-label stretched-link"
                @click="manageClothingType(clothingTypes[3])"
                >{{ clothingTypes[3] }}</label
              >
            </li>
            <li class="list-group-item types-list-item">
              <label
                class="form-check-label stretched-link"
                @click="manageClothingType(clothingTypes[4])"
                >{{ clothingTypes[4] }}</label
              >
            </li>
            <li class="list-group-item types-list-item">
              <label
                class="form-check-label stretched-link"
                @click="manageClothingType(clothingTypes[5])"
                >{{ clothingTypes[5] }}</label
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
            <li class="list-group-item brands-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brandState.adidas"
                id="adidasCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="adidasCheckbox"
                >{{ brands[0] }}</label
              >
            </li>
            <li class="list-group-item brands-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brandState.bidiBadu"
                id="bidiBaduCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="bidiBaduCheckbox"
                >{{ brands[1] }}</label
              >
            </li>
            <li class="list-group-item brands-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brandState.head"
                id="headCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="headCheckbox"
                >{{ brands[2] }}</label
              >
            </li>
            <li class="list-group-item brands-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brandState.nike"
                id="nikeCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="nikeCheckbox"
                >{{ brands[3] }}</label
              >
            </li>
            <li class="list-group-item brands-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brandState.underArmour"
                id="underArmourCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="underArmourCheckbox"
                >{{ brands[4] }}</label
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
            <li class="list-group-item sizes-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="sizeState.small"
                id="smallCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="smallCheckbox"
                >{{ sizes[0] }}</label
              >
            </li>
            <li class="list-group-item sizes-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="sizeState.medium"
                id="mediumCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="mediumCheckbox"
                >{{ sizes[1] }}</label
              >
            </li>
            <li class="list-group-item sizes-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="sizeState.large"
                id="largeCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="largeCheckbox"
                >{{ sizes[2] }}</label
              >
            </li>
            <li class="list-group-item sizes-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="sizeState.xlarge"
                id="xlargeCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="xlargeCheckbox"
                >{{ sizes[3] }}</label
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
            <li class="list-group-item colours-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colourState.black"
                id="blackCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="blackCheckbox"
                >{{ colours[0] }}</label
              >
            </li>
            <li class="list-group-item colours-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colourState.blue"
                id="blueCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="blueCheckbox"
                >{{ colours[1] }}</label
              >
            </li>
            <li class="list-group-item colours-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colourState.white"
                id="whiteCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="whiteCheckbox"
                >{{ colours[2] }}</label
              >
            </li>
            <li class="list-group-item colours-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colourState.grey"
                id="greyCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="greyCheckbox"
                >{{ colours[3] }}</label
              >
            </li>
            <li class="list-group-item colours-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colourState.red"
                id="redCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="redCheckbox"
                >{{ colours[4] }}</label
              >
            </li>
            <li class="list-group-item colours-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colourState.green"
                id="greenCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="greenCheckbox"
                >{{ colours[5] }}</label
              >
            </li>
            <li class="list-group-item colours-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="colourState.yellow"
                id="yellowCheckbox"
                @change="clothingsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="yellowCheckbox"
                >{{ colours[6] }}</label
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
const brands = ["Adidas", "BIDI BADU", "HEAD", "Nike", "Under Armour"];
const sizes = ["S", "M", "L", "XL"];
const colours = ["Black", "Blue", "White", "Grey", "Red", "Green", "Yellow"];
const clothingTypes = ["Hoodie", "Pants", "Dress", "Skirt", "Shirt", "Shorts"];

const brandState = ref({
  adidas: false,
  bidiBadu: false,
  head: false,
  nike: false,
  underArmour: false,
});

const genderState = ref({
  male: false,
  female: false,
});

const sizeState = ref({
  small: false,
  medium: false,
  large: false,
  xlarge: false,
});

const colourState = ref({
  black: false,
  blue: false,
  white: false,
  grey: false,
  red: false,
  green: false,
  yellow: false,
});

const leftPriceSlider = ref(10);
const rightPriceSlider = ref(150);
const clothingType = ref("");

const clothingsFilterEmit = defineEmits("filter-clothings");

// function constructs filter object and emits it to parent(RacketVue)
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
    name: clothingType.value,
  });

  // brands
  brandsToFilter.push({ name: brands[0], value: brandState.value.adidas });
  brandsToFilter.push({ name: brands[1], value: brandState.value.bidiBadu });
  brandsToFilter.push({ name: brands[2], value: brandState.value.head });
  brandsToFilter.push({ name: brands[3], value: brandState.value.nike });
  brandsToFilter.push({ name: brands[4], value: brandState.value.underArmour });

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
  sizesToFilter.push({ name: sizes[0], value: sizeState.value.small });
  sizesToFilter.push({ name: sizes[1], value: sizeState.value.medium });
  sizesToFilter.push({ name: sizes[2], value: sizeState.value.large });
  sizesToFilter.push({ name: sizes[3], value: sizeState.value.xlarge });

  // colour
  coloursToFilter.push({ name: colours[0], value: colourState.value.black });
  coloursToFilter.push({ name: colours[1], value: colourState.value.blue });
  coloursToFilter.push({ name: colours[2], value: colourState.value.white });
  coloursToFilter.push({ name: colours[3], value: colourState.value.grey });
  coloursToFilter.push({ name: colours[4], value: colourState.value.red });
  coloursToFilter.push({ name: colours[5], value: colourState.value.green });
  coloursToFilter.push({ name: colours[6], value: colourState.value.yellow });

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
  clothingType.value = type;
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
