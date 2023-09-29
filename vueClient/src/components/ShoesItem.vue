<template>
  <div class="container" v-if="shoes != undefined">
    <div class="row shoesSection1">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="shoesName">
          <h4>{{ shoes?.brand }}</h4>
          <span id="shoesTitle">{{ shoes?.name }}</span>
          <p class="itemNo">Item #: 0090620282400{{ shoes?.id }}</p>
          <div class="shoesRating">
            <div class="ratingWrapper">
              <span
                v-for="index in Math.floor(shoes?.rating)"
                style="color: #ffed00"
                >★</span
              >
              <span v-for="index in 5 - Math.floor(shoes?.rating)">★</span>
            </div>
            <p>{{ shoes?.rating }}</p>
          </div>
          <div class="shoesFeatures">
            <ul>
              <li v-if="shoes?.gender">Gender: Men</li>
              <li v-else>Gender: Women</li>
              <li>Colour: {{ shoes?.color }}</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 shoesImg">
        <img v-bind:src="shoes?.img" alt="shoes" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="shoesOtherFeatures">
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
            <h5>Size</h5>
            <button
              v-for="size in shoesSizes"
              :disabled="getSizeDynamic(size, shoes?.size)"
            >
              {{ size }}
            </button>
          </div>
          <div class="quantity">
            <p class="inStock" v-if="shoes?.quantity > 0">In Stock</p>
            <p class="outOfStock" v-else>Out of Stock</p>
            <p class="deliveryTime" v-if="shoes?.quantity > 0">
              Deliverytime 5 - 6 days. <br />
              Delivery between {{ deliveryTime() }}
            </p>
            <p><b>Quantity</b></p>
            <div class="quantityCounter">
              <button @click="decrementAmount">
                <img src="../img/minus-icon.svg" />
              </button>
              <input type="number" v-model="shoesAmount" />
              <button @click="incrementAmount">
                <img src="../img/plus-icon.svg" />
              </button>
            </div>
          </div>
          <button class="btn btn-success" @click="addToCart">
            Add to cart
          </button>
          <p class="deliveryVat">incl. VAT, incl. shipping</p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col col-md-6">
        <div class="shoesDescription">
          <h5>Description</h5>
          <p class="shoesDescName">
            {{ shoes?.brand }} <br />
            {{ shoes?.name }}
          </p>
          <p>{{ shoes?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarShoesWrapper">
          <h5>Similar Products</h5>
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
                      <b>{{ shoes?.brand }}</b> <br />
                      {{ shoes?.name }}
                    </p>
                    <div class="simillarShoesPrice">
                      <span v-if="shoes?.salePrice === 0">
                        <b>€ {{ shoes?.price }}</b>
                      </span>
                      <span v-else>
                        <b>€ {{ shoes?.salePrice }}</b>
                        <del>€ {{ shoes?.price }}</del> <br />
                      </span>
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
                      </div>
                      <p>{{ shoes?.rating }}</p>
                    </div>
                    <div class="simillarShoesRating" v-else></div>
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

// calculate delivery time
const deliveryTime = () => {
  // get todays date
  const now = new Date();

  // construct 5 days ahead date
  const fiveDaysAhead = new Date();
  fiveDaysAhead.setDate(now.getDate() + 5);

  // construct 6 days ahead date
  const sixDaysAhead = new Date();
  sixDaysAhead.setDate(now.getDate() + 6);

  // return string
  return `${fiveDaysAhead.toDateString()} - ${sixDaysAhead.toDateString()}`;
};
</script>

<style lang="scss">
@import "../assets/sass";

.shoesSection1 {
  margin-top: 55px;
  margin-bottom: 60px;
  .shoesName {
    h4 {
      font-weight: 700;
      color: #424242;
    }

    #shoesTitle {
      font-size: 20px;
    }

    .itemNo {
      font-size: 14px;
      margin-top: 0px;
      margin-bottom: -3px;
    }

    .shoesRating {
      @include displayFlex(row);
      align-items: center;

      .ratingWrapper {
        span {
          font-size: 28px;
        }
      }

      p {
        display: inline-block;
        margin: 0;
        padding-top: 4px;
        padding-left: 10px;
        font-weight: 600;
      }
    }

    .shoesFeatures {
      margin-top: 50px;

      ul {
        li {
          list-style-image: url("../img/list-ball-grey.svg");
          margin-bottom: 10px;
        }
      }
    }
  }

  .shoesImg {
    img {
      height: 400px;
      width: auto;
      // object-fit: cover;
      // object-position: 65% 100%;
      transition: transform 0.5s ease;
      margin-left: -20px;

      &:hover {
        cursor: zoom-in;
        transform: scale(1.125);
      }
    }
  }

  .shoesOtherFeatures {
    padding-left: 100px;
    .price {
      span {
        del {
          color: grey;
        }

        b {
          font-size: 24px;
        }
      }
    }
    .shoesSize {
      padding: 30px 0 10px 0;

      h5 {
        font-size: 16px;
        font-weight: 600;
      }

      button {
        margin-right: 10px;
        margin-bottom: 10px;
        height: 40px;
        width: 45px;
        border: 0.5px solid rgb(183, 183, 183);
      }
    }

    .quantity {
      .inStock {
        font-weight: 600;
        color: #adce4e;
      }

      .outOfStock {
        font-weight: 600;
        color: rgb(193, 193, 193);
      }

      .quantityCounter {
        button {
          border: none;
          background: none;

          img {
            height: 20px;
            width: 20px;
          }
        }

        input {
          width: 70px;
          height: 39px;
          text-align: center;
          padding-left: 17px;
          margin: 0 10px;
        }
      }
    }

    .btn-success {
      margin-top: 30px;
      width: 250px;
      height: 50px;
      border-radius: 0;
      background-color: #cee28e;
      border: none;
      font-size: 22px;
      font-weight: 600;
    }

    .deliveryVat {
      margin-top: 5px;
      font-size: 12px;
    }
  }
}

.shoesDescription,
.simillarShoesWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.shoesDescription {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .shoesDescName {
    font-size: 20px;
    font-weight: 600;
  }
}

.simillarShoesWrapper {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .simillarShoes {
    @include displayFlex(row);
    font-size: 14px;

    .card {
      display: flex;
      justify-content: center;
      align-items: center;

      .card-body {
        text-align: center;

        .card-text {
          min-height: 63px;
        }

        .simillarShoesPrice {
          del {
            padding-left: 15px;
            color: grey;
          }
        }

        .simillarShoesRating {
          @include displayFlex(row);
          align-items: center;
          justify-content: center;
          min-height: 36px;

          .ratingWrapper {
            span {
              font-size: 24px;
            }
          }

          p {
            display: inline-block;
            margin: 0;
            padding-top: 4px;
          }
        }
      }
    }
  }
}
</style>
