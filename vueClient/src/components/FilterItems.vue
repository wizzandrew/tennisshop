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
                value=""
                id="babolatCheckbox"
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
                value=""
                id="headCheckbox"
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
                value=""
                id="wilsonCheckbox"
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
              max="199"
              @change="validateRange"
            />
            <input
              type="range"
              class="max-price"
              v-model="rightPriceSlider"
              min="51"
              max="200"
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
                value=""
                id="weightSmallCheckbox"
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
                value=""
                id="weightMediumCheckbox"
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
                value=""
                id="weightLargeCheckbox"
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
                value=""
                id="headSizeSmallCheckbox"
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
                value=""
                id="headSizeMediumCheckbox"
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
                value=""
                id="headSizeLargeCheckbox"
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
                value=""
                id="gripSizeSmallCheckbox"
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
                value=""
                id="gripSizeMediumCheckbox"
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
                value=""
                id="gripSizeLargeCheckbox"
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
const weight = [250, 275, 276, 258, 286, 295];
const headSize = [600, 626, 627, 632, 633, 645];
const gripSize = [1, 2, 3];

const leftPriceSlider = ref(50);
const rightPriceSlider = ref(200);

const validateRange = () => {
  if (Number(leftPriceSlider.value) > Number(rightPriceSlider.value)) {
    leftPriceSlider.value = 50;
    rightPriceSlider.value = 200;
  }
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
