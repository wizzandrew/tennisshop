<template>
  <div class="filterWrapper">
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
                v-model="brandState.babolat"
                id="babolatCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="babolatCheckbox"
                >{{ brands[0] }}</label
              >
            </li>
            <li class="list-group-item brands-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brandState.head"
                id="headCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="headCheckbox"
                >{{ brands[1] }}</label
              >
            </li>
            <li class="list-group-item brands-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="brandState.wilson"
                id="wilsonCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="wilsonCheckbox"
                >{{ brands[2] }}</label
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
            <li class="list-group-item weight-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="weightState.smallWeight"
                id="weightSmallCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="weightSmallCheckbox"
                >{{ weight[0] }} g - {{ weight[1] }} g</label
              >
            </li>
            <li class="list-group-item weight-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="weightState.mediumWeight"
                id="weightMediumCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="weightMediumCheckbox"
                >{{ weight[2] }} g - {{ weight[3] }} g</label
              >
            </li>
            <li class="list-group-item weight-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="weightState.largeWeight"
                id="weightLargeCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="weightLargeCheckbox"
                >{{ weight[4] }} g - {{ weight[5] }} g</label
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
            <li class="list-group-item headSize-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="headState.smallHead"
                id="headSizeSmallCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="headSizeSmallCheckbox"
                >{{ headSize[0] }} cm<sup>2</sup> - {{ headSize[1] }} cm<sup
                  >2</sup
                ></label
              >
            </li>
            <li class="list-group-item headSize-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="headState.mediumHead"
                id="headSizeMediumCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="headSizeMediumCheckbox"
                >{{ headSize[2] }} cm<sup>2</sup> - {{ headSize[3] }} cm<sup
                  >2</sup
                ></label
              >
            </li>
            <li class="list-group-item headSize-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="headState.largeHead"
                id="headSizeLargeCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="headSizeLargeCheckbox"
                >{{ headSize[4] }} cm<sup>2</sup> - {{ headSize[5] }} cm<sup
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
            <li class="list-group-item gripSize-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="gripSizeState.grip1"
                id="gripSizeSmallCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="gripSizeSmallCheckbox"
                >{{ gripSize[0] }}</label
              >
            </li>
            <li class="list-group-item gripSize-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="gripSizeState.grip2"
                id="gripSizeMediumCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="gripSizeMediumCheckbox"
                >{{ gripSize[1] }}</label
              >
            </li>
            <li class="list-group-item gripSize-list-item">
              <input
                class="form-check-input me-1"
                type="checkbox"
                v-model="gripSizeState.grip3"
                id="gripSizeLargeCheckbox"
                @change="racketsFilter"
              />
              <label
                class="form-check-label stretched-link"
                for="gripSizeLargeCheckbox"
                >{{ gripSize[2] }}</label
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { onMounted, ref } from "vue";
const brands = ["Babolat", "HEAD", "Wilson"];
const weight = ["250", "275", "276", "285", "286", "295"];
const headSize = ["600", "626", "627", "632", "633", "645"];
const gripSize = ["1", "2", "3"];

const brandState = ref({
  babolat: false,
  head: false,
  wilson: false,
});

const weightState = ref({
  smallWeight: false,
  mediumWeight: false,
  largeWeight: false,
});

const headState = ref({
  smallHead: false,
  mediumHead: false,
  largeHead: false,
});

const gripSizeState = ref({
  grip1: false,
  grip2: false,
  grip3: false,
});

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
  brandsToFilter.push({ name: brands[0], value: brandState.value.babolat });
  brandsToFilter.push({ name: brands[1], value: brandState.value.head });
  brandsToFilter.push({ name: brands[2], value: brandState.value.wilson });

  // price
  pricesToFilter.push({
    min: leftPriceSlider.value,
    max: rightPriceSlider.value,
  });

  // weights
  weigtsToFilter.push({
    min: weight[0],
    max: weight[1],
    value: weightState.value.smallWeight,
  });
  weigtsToFilter.push({
    min: weight[2],
    max: weight[3],
    value: weightState.value.mediumWeight,
  });
  weigtsToFilter.push({
    min: weight[4],
    max: weight[5],
    value: weightState.value.largeWeight,
  });

  // head sizes
  headsToFilter.push({
    min: headSize[0],
    max: headSize[1],
    value: headState.value.smallHead,
  });
  headsToFilter.push({
    min: headSize[2],
    max: headSize[3],
    value: headState.value.mediumHead,
  });
  headsToFilter.push({
    min: headSize[4],
    max: headSize[5],
    value: headState.value.largeHead,
  });

  // grip sizes
  gripsToFilter.push({ grip: gripSize[0], value: gripSizeState.value.grip1 });
  gripsToFilter.push({ grip: gripSize[1], value: gripSizeState.value.grip2 });
  gripsToFilter.push({ grip: gripSize[2], value: gripSizeState.value.grip3 });

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
