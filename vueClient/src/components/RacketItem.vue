<template>
  <div class="container" v-if="racket != undefined">
    <div class="row racketSection1">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="racketName">
          <h4>{{ racket?.brand }}</h4>
          <span id="racketTitle">{{ racket?.name }}</span>
          <p class="itemNo">Item #: 0090620286300{{ racket?.id }}</p>
          <div class="racketRating">
            <div class="ratingWrapper">
              <span
                v-for="index in Math.floor(racket?.rating)"
                style="color: #ffed00"
                >★</span
              >
              <span v-for="index in 5 - Math.floor(racket?.rating)">★</span>
            </div>
            <p>{{ racket?.rating }}</p>
          </div>
          <div class="racketFeatures">
            <ul>
              <li>Head size (cm<sup>2</sup>): {{ racket?.headSize }}</li>
              <li>Weight (g): {{ racket?.weight }}</li>
              <li>String pattern: 16/19</li>
              <li>Strung: No</li>
              <li>Balance (mm): 305</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 racketImg">
        <img v-bind:src="racket?.img" alt="racket" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="racketOtherFeatures">
          <div class="price">
            <span v-if="racket?.salePrice === 0"
              ><b>€ {{ racket?.price }}</b></span
            >
            <span v-else
              ><del>€ {{ racket?.price }}</del> <br />
              <b>€ {{ racket?.salePrice }}</b></span
            >
          </div>
          <div class="gripSize">
            <h5>Grip size</h5>
            <button
              v-for="grip in grips"
              :disabled="getGripDynamic(grip, racket.gripSize)"
            >
              {{ grip }}
            </button>
          </div>
          <div class="quantity">
            <p class="inStock" v-if="racket?.quantity > 0">In Stock</p>
            <p class="outOfStock" v-else>Out Of Stock</p>
            <p class="deliveryTime" v-if="racket?.quantity > 0">
              Deliverytime 5 - 6 days. <br />
              Delivery between {{ deliveryTime() }}
            </p>
            <p><b>Quantity</b></p>
            <div class="quantityCounter">
              <button @click="decrementAmount">
                <img src="../img/minus-icon.svg" />
              </button>
              <input type="number" v-model="racketAmount" />
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
        <div class="racketDescription">
          <h5>Description</h5>
          <p class="racketDescName">
            {{ racket?.brand }} <br />
            {{ racket?.name }}
          </p>
          <p>{{ racket?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarRacketsWrapper">
          <h5>Similar Products</h5>
          <div class="row simillarRackets">
            <div class="col-4 similarRacket" v-for="racket in simillarRackets">
              <router-link
                :to="getRacketLink(racket.id)"
                style="color: black; text-decoration: none"
              >
                <div class="card">
                  <img
                    v-bind:src="racket?.img"
                    class="card-img-top"
                    alt="racket"
                  />
                  <div class="card-body">
                    <p class="card-text">
                      <b>{{ racket?.brand }}</b> <br />
                      {{ racket?.name }}
                    </p>
                    <div class="simillarRacketPrice">
                      <span v-if="racket?.salePrice === 0"
                        ><b>€ {{ racket?.price }}</b></span
                      >
                      <span v-else
                        ><b>€ {{ racket?.salePrice }}</b>
                        <del>€ {{ racket?.price }}</del>
                      </span>
                    </div>
                    <div class="simillarRacketRating" v-if="racket?.rating">
                      <div class="ratingWrapper">
                        <span
                          v-for="index in Math.floor(racket?.rating)"
                          style="color: #ffed00"
                          >★</span
                        >
                        <span v-for="index in 5 - Math.floor(racket?.rating)"
                          >★</span
                        >
                      </div>
                      <p>{{ racket?.rating }}</p>
                    </div>
                    <div class="simillarRacketRating" v-else></div>
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
// initial rackets retrieved from db
const { racketItems } = storeToRefs(store);

// racket
const racket = ref();
const simillarRackets = ref([]);

// grip array that helps to set disabled to button
// disabled -> grip that isnt available with this racket
const grips = ["1", "2", "3"];
const getGripDynamic = (grip, racketGrip) => {
  return grip === racketGrip ? false : true;
};

// racket amount
const racketAmount = ref(1);

const incrementAmount = () => {
  racketAmount.value++;
  validateRacketAmount();
};

const decrementAmount = () => {
  racketAmount.value--;
  validateRacketAmount();
};

const validateRacketAmount = () => {
  if (racketAmount.value < 0) {
    racketAmount.value = 0;
  }

  if (racketAmount.value > racket.value?.quantity) {
    racketAmount.value--;
    alert("Maximum available amount: " + racketAmount.value);
  }
};

const getSimillarRackets = () => {
  let simillar = racketItems.value.slice(0, 4);
  simillar = simillar.filter((r) => r.id != racket.value?.id);
  return simillar.slice(0, 3);
};

// creates link for single racket
const getRacketLink = (id) => {
  return `/racket/${id}`;
};

// loads racket and simillar accessories racket
const processRacketState = () => {
  // set racket
  racket.value = racketItems.value.find((r) => r.id === Number(props.id));

  // set simillar rackets
  simillarRackets.value = getSimillarRackets();
};

onMounted(() => {
  processRacketState();
});

// add item to cart
const addToCart = () => {
  store.addToShoppingCart({ item: racket.value, amount: racketAmount.value });
  racketAmount.value = 1;
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

.racketSection1 {
  margin-top: 55px;
  .racketName {
    h4 {
      font-weight: 700;
      color: #424242;
    }

    #racketTitle {
      font-size: 20px;
    }

    .itemNo {
      font-size: 14px;
      margin-top: 0px;
      margin-bottom: -3px;
    }

    .racketRating {
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

    .racketFeatures {
      margin-top: 50px;

      ul {
        li {
          list-style-image: url("../img/list-ball-grey.svg");
          margin-bottom: 10px;
        }
      }
    }
  }

  .racketImg {
    img {
      height: 600px;
      width: 100%;
      object-fit: cover;
      object-position: 65% 100%;
      transition: transform 0.5s ease;

      &:hover {
        cursor: zoom-in;
        transform: scale(1.125);
      }
    }
  }

  .racketOtherFeatures {
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
    .gripSize {
      padding: 30px 0 10px 0;

      h5 {
        font-size: 16px;
        font-weight: 600;
      }

      button {
        margin-right: 10px;
        height: 40px;
        width: 40px;
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

.racketDescription,
.simillarRacketsWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.racketDescription {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .racketDescName {
    font-size: 20px;
    font-weight: 600;
  }
}

.simillarRacketsWrapper {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .simillarRackets {
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

        .simillarRacketPrice {
          del {
            padding-left: 15px;
            color: grey;
          }
        }

        .simillarRacketRating {
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
