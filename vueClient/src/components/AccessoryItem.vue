<template>
  <div class="container" v-if="accessories != undefined">
    <div class="row accessoriesSection1">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="accessoriesName">
          <h4>{{ accessories?.brand }}</h4>
          <span id="accessoriesTitle">{{ accessories?.name }}</span>
          <p class="itemNo">Item #: 0090620282100{{ accessories?.id }}</p>
          <div class="accessoriesRating">
            <div class="ratingWrapper">
              <span
                v-for="index in Math.floor(accessories?.rating)"
                style="color: #ffed00"
                >★</span
              >
              <span v-for="index in 5 - Math.floor(accessories?.rating)"
                >★</span
              >
            </div>
            <p>{{ accessories?.rating }}</p>
          </div>
          <div class="accessoriesFeatures">
            <ul>
              <li>Type: {{ accessories?.type }}</li>
              <li>Colour: {{ accessories?.color }}</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 accessoriesImg">
        <img v-bind:src="accessories?.img" alt="accessories" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="accessoriesOtherFeatures">
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
            <h5 v-if="accessories.type === 'Strings'">String gauge (mm)</h5>
            <h5 v-else>Size</h5>
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
            <p class="inStock" v-if="accessories?.quantity > 0">In Stock</p>
            <p class="outOfStock" v-else>Out of Stock</p>
            <p class="deliveryTime" v-if="accessories?.quantity > 0">
              Deliverytime 5 - 6 days. <br />
              Delivery between {{ deliveryTime() }}
            </p>
            <p><b>Quantity</b></p>
            <div class="quantityCounter">
              <button @click="decrementAmount">
                <img src="../img/minus-icon.svg" />
              </button>
              <input type="number" v-model="accessoriesAmount" />
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
        <div class="accessoriesDescription">
          <h5>Description</h5>
          <p>
            {{ accessories?.brand }} <br />
            {{ accessories?.name }}
          </p>
          <p>{{ accessories?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarAccessoriesWrapper">
          <h5>Similar Products</h5>
          <div class="row simillarAccessories">
            <div
              class="col-4 similarAccessory"
              v-for="accessories in simillarAccessories"
            >
              <router-link
                :to="getAccessoryLink(accessories?.id)"
                style="color: black; text-decoration: none"
              >
                <div class="card">
                  <img
                    v-bind:src="accessories?.img"
                    class="card-img-top"
                    alt="clothing"
                  />
                  <div class="card-body">
                    <p class="card-text">
                      <b>{{ accessories?.brand }}</b> <br />
                      {{ accessories?.name }}
                    </p>
                    <div class="simillarAccessoriesPrice">
                      <span v-if="accessories?.salePrice === 0"
                        ><b>€ {{ accessories?.price }}</b></span
                      >
                      <span v-else>
                        <b>€ {{ accessories?.salePrice }}</b>
                        <del>€ {{ accessories?.price }}</del> <br />
                      </span>
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
                        <span
                          v-for="index in 5 - Math.floor(accessories?.rating)"
                          >★</span
                        >
                      </div>
                      <p>{{ accessories?.rating }}</p>
                    </div>
                    <div class="simillarAccessoriesRating" v-else></div>
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

// creates link for single accessory
const getAccessoryLink = (id) => {
  return `/accessory/${id}`;
};

// loads accessory and simillar accessories state
const processAccessoryState = () => {
  // set accessories
  accessories.value = accessoryItems.value.find(
    (a) => a.id === Number(props.id)
  );

  // set simillar clothings
  simillarAccessories.value = getSimillarAccessories();
};

onMounted(() => {
  processAccessoryState();
});

// add item to cart
const addToCart = () => {
  store.addToShoppingCart({
    item: accessories.value,
    amount: accessoriesAmount.value,
  });
  accessoriesAmount.value = 1;
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

.accessoriesSection1 {
  margin-top: 55px;
  .accessoriesName {
    h4 {
      font-weight: 700;
      color: #424242;
    }

    #accessoriesTitle {
      font-size: 20px;
    }

    .itemNo {
      font-size: 14px;
      margin-top: 0px;
      margin-bottom: -3px;
    }

    .accessoriesRating {
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

    .accessoriesFeatures {
      margin-top: 50px;

      ul {
        li {
          list-style-image: url("../img/list-ball-grey.svg");
          margin-bottom: 10px;
        }
      }
    }
  }

  .accessoriesImg {
    img {
      height: 500px;
      width: 116%;
      object-fit: cover;
      // object-position: 65% 100%;
      transition: transform 0.5s ease;

      &:hover {
        cursor: zoom-in;
        transform: scale(1.125);
      }
    }
  }

  .accessoriesOtherFeatures {
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
    .accessoriesSize {
      padding: 30px 0 10px 0;

      h5 {
        font-size: 16px;
        font-weight: 600;
      }

      button {
        margin-right: 10px;
        height: 40px;
        width: 80px;
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

.accessoriesDescription,
.simillarAccessoriesWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.accessoriesDescription {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .accessoriesDescName {
    font-size: 20px;
    font-weight: 600;
  }
}

.simillarAccessoriesWrapper {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .simillarAccessories {
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

        .simillarAccessoriesPrice {
          del {
            padding-left: 15px;
            color: grey;
          }
        }

        .simillarAccessoriesRating {
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
