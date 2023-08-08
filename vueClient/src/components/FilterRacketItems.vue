<template>
  <div class="filterWrapper">
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
                @change="racketsFilter"
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
              min="50"
              max="299"
              @change="validateRange"
            />
            <input
              type="range"
              class="max-price"
              v-model="rightPriceSlider"
              min="51"
              max="300"
              @change="validateRange"
            />
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Weight</h6>
        <hr />
        <div class="weightFilter">
          <ul class="list-group weight-list">
            <li
              class="list-group-item weight-list-item"
              v-for="weight in weightState"
            >
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="weight.value"
                v-bind:id="dynamicAttr(weight.min, 'Checkbox')"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                v-bind:for="dynamicAttr(weight.min, 'Checkbox')"
                >{{ weight.min }} g - {{ weight.max }} g</label
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Head size</h6>
        <hr />
        <div class="headSizeFilter">
          <ul class="list-group headSize-list">
            <li
              class="list-group-item headSize-list-item"
              v-for="head in headState"
            >
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="head.value"
                v-bind:id="dynamicAttr(head.min, 'Checkbox')"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                v-bind:for="dynamicAttr(head.min, 'Checkbox')"
                >{{ head.min }} cm<sup>2</sup> - {{ head.max }} cm<sup
                  >2</sup
                ></label
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h6>Grip size</h6>
        <hr />
        <div class="gripSizeFilter">
          <ul class="list-group gripSize-list">
            <li
              class="list-group-item gripSize-list-item"
              v-for="grip in gripSizeState"
            >
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="grip.value"
                v-bind:id="dynamicAttr(grip.grip, 'Checkbox')"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                v-bind:for="dynamicAttr(grip.grip, 'Checkbox')"
                >{{ grip.grip }}</label
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

const brandState = ref([
  { name: "Babolat", value: false },
  { name: "HEAD", value: false },
  { name: "Wilson", value: false },
]);

const weightState = ref([
  { min: "250", max: "275", value: false },
  { min: "276", max: "285", value: false },
  { min: "286", max: "295", value: false },
]);

const headState = ref([
  { min: "600", max: "626", value: false },
  { min: "627", max: "632", value: false },
  { min: "633", max: "645", value: false },
]);

const gripSizeState = ref([
  { grip: "1", value: false },
  { grip: "2", value: false },
  { grip: "3", value: false },
]);

const leftPriceSlider = ref(50);
const rightPriceSlider = ref(300);

const racketsFilterEmit = defineEmits("filter-rackets");

// function constructs filter object and emits it to parent(RacketVue)
const racketsFilter = () => {
  // arrays to hold filter state and checkbox value
  const brandsToFilter = [];
  const pricesToFilter = [];
  const weigtsToFilter = [];
  const headsToFilter = [];
  const gripsToFilter = [];

  // brands
  brandState.value.forEach((element) => {
    brandsToFilter.push(element);
  });

  // price
  pricesToFilter.push({
    min: leftPriceSlider.value,
    max: rightPriceSlider.value,
  });

  // weights
  weightState.value.forEach((element) => {
    weigtsToFilter.push(element);
  });

  // head sizes
  headState.value.forEach((element) => {
    headsToFilter.push(element);
  });

  // grip sizes
  gripSizeState.value.forEach((element) => {
    gripsToFilter.push(element);
  });

  // construct filter object
  const filterObject = {
    brands: brandsToFilter,
    prices: pricesToFilter,
    weights: weigtsToFilter,
    headSizes: headsToFilter,
    gripSizes: gripsToFilter,
  };

  racketsFilterEmit("filter-rackets", filterObject);
};

// make sure left price doesnt become bigger than right price
// e.g user grags left price across right price
const validateRange = () => {
  if (Number(leftPriceSlider.value) > Number(rightPriceSlider.value)) {
    leftPriceSlider.value = 50;
    rightPriceSlider.value = 300;
  }

  // call racketsFilter() to proceed to emit
  racketsFilter();
};

// gives dynamic id for <input>
const dynamicAttr = (property, string) => {
  return property + "rackets" + string;
};
</script>

<style lang="scss">
@import "../assets//sass";

.filterWrapper {
  @include filterItems;
}
</style>
