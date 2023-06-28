<template>
  <div class="container" v-if="accessories != undefined">
    <div class="row">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="accessoriesInfo1">
          <h5>{{ accessories?.brand }}</h5>
          <span>{{ accessories?.name }}</span>
          <div>
            <span
              v-for="index in Math.floor(accessories?.rating)"
              style="color: #ffed00"
              >★</span
            >
            <span v-for="index in 5 - Math.floor(accessories?.rating)">★</span>
            <span>{{ accessories?.rating }}</span>
          </div>
          <div class="accessoriesInfo2">
            <ul>
              <li>{{ accessories?.type }}</li>
              <li>{{ accessories?.color }}</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 accessoriesImg">
        <img v-bind:src="accessories?.img" alt="accessories" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="accessoriesgInfo3">
          <div class="price">
            <span v-if="accessories?.salePrice === 0"
              ><b>€ {{ accessories?.price }}</b></span
            >
            <span v-else
              ><del>€ {{ accessories?.price }}</del> <br />
              <b>€ {{ accessories?.salePrice }}</b></span
            >
          </div>
          <div class="accessoriesSize">
            <h5>Size</h5>
            <button
              v-if="accessories.type === 'Strings'"
              v-for="size in stringsSizes"
              :disabled="getSizeDynamic(size, accessories?.size)"
            >
              {{ size }}
            </button>
            <button v-else>{{ accessories?.size }}</button>
          </div>
          <div class="quantity">
            <p v-if="accessories?.quantity > 0">In Stock</p>
            <p v-else>Out of Stock</p>
            <p><b>Quantity</b></p>
            <button @click="decrementAmount">-</button>
            <input type="number" v-model="accessoriesAmount" />
            <button @click="incrementAmount">+</button>
          </div>
          <button class="btn btn-success">Add to cart</button>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col col-md-6">
        <div class="accessoriesDescription">
          <h5>Description</h5>
          <p>{{ accessories?.brand }} {{ accessories?.name }}</p>
          <p>{{ accessories?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarAccessoriesWrapper">
          <h5>Similar</h5>
          <div class="row simillarAccessories">
            <div
              class="col-4 similarAccessory"
              v-for="accessories in simillarAccessories"
            >
              <div class="card">
                <img
                  v-bind:src="accessories?.img"
                  class="card-img-top"
                  alt="clothing"
                />
                <div class="card-body">
                  <p class="card-text">
                    <b>{{ accessories?.brand }}</b> {{ accessories?.name }}
                  </p>
                  <div class="simillarAccessoriesPrice">
                    <span v-if="accessories?.salePrice === 0"
                      ><b>€ {{ accessories?.price }}</b></span
                    >
                    <span v-else
                      ><del>€ {{ accessories?.price }}</del> <br />
                      <b>€ {{ accessories?.salePrice }}</b></span
                    >
                  </div>
                  <div
                    class="simillarAccessoriesRating"
                    v-if="accessories?.rating"
                  >
                    <div class="ratingWrapper">
                      <span
                        v-for="index in Math.floor(accessories?.rating)"
                        style="color: #ffed00"
                        >★</span
                      >
                      <span v-for="index in 5 - Math.floor(accessories?.rating)"
                        >★</span
                      >
                      <span>{{ accessories?.rating }}</span>
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
// initial accessories retrieved from db
const { accessoryItems } = storeToRefs(store);

// accessories
const accessories = ref();
const simillarAccessories = ref([]);

// size array that helps to set disabled to button
// disabled -> size that isnt available with this accessories
const stringsSizes = ["1.20", "1.25", "1.30"];
const getSizeDynamic = (size, stringsSizes) => {
  return size === stringsSizes ? false : true;
};

// accessories amount
const accessoriesAmount = ref(1);

const incrementAmount = () => {
  accessoriesAmount.value++;
  validateAccessoriesAmount();
};

const decrementAmount = () => {
  accessoriesAmount.value--;
  validateAccessoriesAmount();
};

const validateAccessoriesAmount = () => {
  if (accessoriesAmount.value < 0) {
    accessoriesAmount.value = 0;
  }

  if (accessoriesAmount.value > accessories.value?.quantity) {
    accessoriesAmount.value--;
    alert("Maximum available amount: " + accessoriesAmount.value);
  }
};

const getSimillarAccessories = () => {
  let simillar = accessoryItems.value
    .filter((a) => a.type == accessories.value.type)
    .slice(0, 4);
  simillar = simillar.filter((a) => a.id != accessories.value?.id);
  return simillar.slice(0, 3);
};

onMounted(() => {
  // set accessories
  accessories.value = accessoryItems.value.find(
    (a) => a.id === Number(props.id)
  );

  // set simillar clothings
  simillarAccessories.value = getSimillarAccessories();
});
</script>

<style lang="scss">
@import "../assets/sass";

.accessoriesInfo1 {
  .accessoriesInfo2 {
    margin-top: 50px;
  }
}

.accessoriesImg {
  img {
    height: 500px;
    width: 100%;
    object-fit: contain;
  }
}

.accessoriesInfo3 {
  .accessoriesSize {
    padding: 50px 0;
    button {
      margin-right: 10px;
    }
  }

  .btn-success {
    margin-top: 20px;
  }
}

.accessoriesDescription,
.simillarAccessoriesWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.simillarAccessoriesWrapper {
  .simillarAccessories {
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
