<template>
  <div class="container" v-if="clothing != undefined">
    <div class="row">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="clothingInfo1">
          <h5>{{ clothing?.brand }}</h5>
          <span>{{ clothing?.name }}</span>
          <div>
            <span
              v-for="index in Math.floor(clothing?.rating)"
              style="color: #ffed00"
              >★</span
            >
            <span v-for="index in 5 - Math.floor(clothing?.rating)">★</span>
            <span>{{ clothing?.rating }}</span>
          </div>
          <div class="clothingInfo2">
            <ul>
              <li>{{ clothing?.type }}</li>
              <li v-if="clothing?.gender">Men</li>
              <li v-else>Women</li>
              <li>{{ clothing?.color }}</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 clothingImg">
        <img v-bind:src="clothing?.img" alt="clothing" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="clothingInfo3">
          <div class="price">
            <span v-if="clothing?.salePrice === 0"
              ><b>€ {{ clothing?.price }}</b></span
            >
            <span v-else
              ><del>€ {{ clothing?.price }}</del> <br />
              <b>€ {{ clothing?.salePrice }}</b></span
            >
          </div>
          <div class="clothingSize">
            <h5>Size</h5>
            <button
              v-for="size in clothingSizes"
              :disabled="getSizeDynamic(size, clothing?.size)"
            >
              {{ size }}
            </button>
          </div>
          <div class="quantity">
            <p v-if="clothing?.quantity > 0">In Stock</p>
            <p v-else>Out of Stock</p>
            <p><b>Quantity</b></p>
            <button @click="decrementAmount">-</button>
            <input type="number" v-model="clothingAmount" />
            <button @click="incrementAmount">+</button>
          </div>
          <button class="btn btn-success">Add to cart</button>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col col-md-6">
        <div class="clothingDescription">
          <h5>Description</h5>
          <p>{{ clothing?.brand }} {{ clothing?.name }}</p>
          <p>{{ clothing?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarClothingsWrapper">
          <h5>Similar</h5>
          <div class="row simillarClothings">
            <div
              class="col-4 similarClothing"
              v-for="clothing in simillarClothings"
            >
              <div class="card">
                <img
                  v-bind:src="clothing?.img"
                  class="card-img-top"
                  alt="clothing"
                />
                <div class="card-body">
                  <p class="card-text">
                    <b>{{ clothing?.brand }}</b> {{ clothing?.name }}
                  </p>
                  <div class="simillarClothingPrice">
                    <span v-if="clothing?.salePrice === 0"
                      ><b>€ {{ clothing?.price }}</b></span
                    >
                    <span v-else
                      ><del>€ {{ clothing?.price }}</del> <br />
                      <b>€ {{ clothing?.salePrice }}</b></span
                    >
                  </div>
                  <div class="simillarClothingRating" v-if="clothing?.rating">
                    <div class="ratingWrapper">
                      <span
                        v-for="index in Math.floor(clothing?.rating)"
                        style="color: #ffed00"
                        >★</span
                      >
                      <span v-for="index in 5 - Math.floor(clothing?.rating)"
                        >★</span
                      >
                      <span>{{ clothing?.rating }}</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <BottomPage />
  </div>
  <div v-else style="height: 90vh">Loading...</div>
</template>

<script setup>
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";
import { ref, onMounted } from "vue";
import BottomPage from "./BottomPage.vue";

const props = defineProps(["id"]);

// pinia
const store = shopStore();
// initial clothings retrieved from db
const { clothingItems } = storeToRefs(store);

// clothing
const clothing = ref();
const simillarClothings = ref([]);

// size array that helps to set disabled to button
// disabled -> size that isnt available with this clothing
const clothingSizes = ["S", "M", "L", "XL"];
const getSizeDynamic = (size, clothingSize) => {
  return size === clothingSize ? false : true;
};

// clothing amount
const clothingAmount = ref(1);

const incrementAmount = () => {
  clothingAmount.value++;
  validateClothingAmount();
};

const decrementAmount = () => {
  clothingAmount.value--;
  validateClothingAmount();
};

const validateClothingAmount = () => {
  if (clothingAmount.value < 0) {
    clothingAmount.value = 0;
  }

  if (clothingAmount.value > clothing.value?.quantity) {
    clothingAmount.value--;
    alert("Maximum available amount: " + clothingAmount.value);
  }
};

const getSimillarClothings = () => {
  let simillar = clothingItems.value
    .filter(
      (c) => c.type == clothing.value.type && c.gender == clothing.value.gender
    )
    .slice(0, 4);
  simillar = simillar.filter((c) => c.id != clothing.value?.id);
  return simillar.slice(0, 3);
};

onMounted(() => {
  // set clothing
  clothing.value = clothingItems.value.find((c) => c.id === Number(props.id));

  // set simillar clothings
  simillarClothings.value = getSimillarClothings();
});
</script>

<style lang="scss">
@import "../assets/sass";

.clothingInfo1 {
  .clothingInfo2 {
    margin-top: 50px;
  }
}

.clothingImg {
  img {
    height: 500px;
    width: 100%;
    object-fit: contain;
  }
}

.clothingInfo3 {
  .clothingSize {
    padding: 50px 0;
    button {
      margin-right: 10px;
    }
  }

  .btn-success {
    margin-top: 20px;
  }
}

.clothingDescription,
.simillarClothingsWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.simillarClothingsWrapper {
  .simillarClothings {
    // @include displayFlex(row);

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
