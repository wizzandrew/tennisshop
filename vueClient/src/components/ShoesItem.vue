<template>
  <div class="container" v-if="shoes != undefined">
    <div class="row">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="shoesInfo1">
          <h5>{{ shoes?.brand }}</h5>
          <span>{{ shoes?.name }}</span>
          <div>
            <span
              v-for="index in Math.floor(shoes?.rating)"
              style="color: #ffed00"
              >★</span
            >
            <span v-for="index in 5 - Math.floor(shoes?.rating)">★</span>
            <span>{{ shoes?.rating }}</span>
          </div>
          <div class="shoesInfo2">
            <ul>
              <li v-if="shoes?.gender">Men</li>
              <li v-else>Women</li>
              <li>{{ shoes?.color }}</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 shoesImg">
        <img v-bind:src="shoes?.img" alt="shoes" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="shoesInfo3">
          <div class="price">
            <span v-if="shoes?.salePrice === 0"
              ><b>€ {{ shoes?.price }}</b></span
            >
            <span v-else
              ><del>€ {{ shoes?.price }}</del> <br />
              <b>€ {{ shoes?.salePrice }}</b></span
            >
          </div>
          <div class="shoesSize">
            <h5>Shoes size</h5>
            <button
              v-for="size in shoesSizes"
              :disabled="getSizeDynamic(size, shoes?.size)"
            >
              {{ size }}
            </button>
          </div>
          <div class="quantity">
            <p v-if="shoes?.quantity > 0">In Stock</p>
            <p v-else>Out of Stock</p>
            <p><b>Quantity</b></p>
            <button @click="decrementAmount">-</button>
            <input type="number" v-model="shoesAmount" />
            <button @click="incrementAmount">+</button>
          </div>
          <button class="btn btn-success" @click="addToCart">
            Add to cart
          </button>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col col-md-6">
        <div class="shoesDescription">
          <h5>Description</h5>
          <p>{{ shoes?.brand }} {{ shoes?.name }}</p>
          <p>{{ shoes?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarShoesWrapper">
          <h5>Similar</h5>
          <div class="row simillarShoes">
            <div class="col-4 similarShoe" v-for="shoes in simillarShoes">
              <router-link
                :to="getShoesLink(shoes.id)"
                style="color: black; text-decoration: none"
              >
                <div class="card">
                  <img
                    v-bind:src="shoes?.img"
                    class="card-img-top"
                    alt="shoes"
                  />
                  <div class="card-body">
                    <p class="card-text">
                      <b>{{ shoes?.brand }}</b> {{ shoes?.name }}
                    </p>
                    <div class="simillarShoesPrice">
                      <span v-if="shoes?.salePrice === 0"
                        ><b>€ {{ shoes?.price }}</b></span
                      >
                      <span v-else
                        ><del>€ {{ shoes?.price }}</del> <br />
                        <b>€ {{ shoes?.salePrice }}</b></span
                      >
                    </div>
                    <div class="simillarShoesRating" v-if="shoes?.rating">
                      <div class="ratingWrapper">
                        <span
                          v-for="index in Math.floor(shoes?.rating)"
                          style="color: #ffed00"
                          >★</span
                        >
                        <span v-for="index in 5 - Math.floor(shoes?.rating)"
                          >★</span
                        >
                        <span>{{ shoes?.rating }}</span>
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
    <BottomPage />
  </div>
  <div v-else style="height: 90vh">Loading...</div>
</template>

<script setup>
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";
import { ref, onMounted, onUpdated } from "vue";
import BottomPage from "./BottomPage.vue";

const props = defineProps(["id"]);

// pinia
const store = shopStore();
// initial shoes retrieved from db
const { shoeItems } = storeToRefs(store);

// shoes
const shoes = ref();
const simillarShoes = ref([]);

// size array that helps to set disabled to button
// disabled -> size that isnt available with this shoes
const shoesSizes = [
  "39",
  "39.5",
  "40",
  "40.5",
  "41",
  "41.5",
  "42",
  "42.5",
  "43",
];
const getSizeDynamic = (size, shoesSize) => {
  return size === shoesSize ? false : true;
};

// shoes amount
const shoesAmount = ref(1);

const incrementAmount = () => {
  shoesAmount.value++;
  validateShoesAmount();
};

const decrementAmount = () => {
  shoesAmount.value--;
  validateShoesAmount();
};

const validateShoesAmount = () => {
  if (shoesAmount.value < 0) {
    shoesAmount.value = 0;
  }

  if (shoesAmount.value > shoes.value?.quantity) {
    shoesAmount.value--;
    alert("Maximum available amount: " + shoesAmount.value);
  }
};

const getSimillarShoes = () => {
  let simillar = shoeItems.value
    .filter((s) => s.gender == shoes.value.gender)
    .slice(0, 4);
  simillar = simillar.filter((s) => s.id != shoes.value?.id);
  return simillar.slice(0, 3);
};

// creates link for single shoes
const getShoesLink = (id) => {
  return `/shoes/${id}`;
};

// loads shoes and simillar shoes state
const processShoesState = () => {
  // set shoes
  shoes.value = shoeItems.value.find((s) => s.id === Number(props.id));

  // set simillar shoes
  simillarShoes.value = getSimillarShoes();
};
onMounted(() => {
  processShoesState();
});

// add item to cart
const addToCart = () => {
  store.addToShoppingCart({ item: shoes.value, amount: shoesAmount.value });
  shoesAmount.value = 1;
};
</script>

<style lang="scss">
@import "../assets/sass";

.shoesInfo1 {
  .shoesInfo2 {
    margin-top: 50px;
  }
}

.shoesImg {
  img {
    height: 500px;
    width: 100%;
    object-fit: contain;
  }
}

.shoesInfo3 {
  .shoesSize {
    padding: 50px 0;
    button {
      margin-right: 10px;
    }
  }

  .btn-success {
    margin-top: 20px;
  }
}

.shoesDescription,
.simillarShoesWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.simillarShoesWrapper {
  .simillarShoes {
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
