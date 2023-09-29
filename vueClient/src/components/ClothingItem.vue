<template>
  <div class="container" v-if="clothing != undefined">
    <div class="row clothingSection1">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="clothingName">
          <h4>{{ clothing?.brand }}</h4>
          <span id="clothingTitle">{{ clothing?.name }}</span>
          <p class="itemNo">Item #: 0090620287500{{ clothing?.id }}</p>
          <div class="clothingRating">
            <div class="clothingWrapper">
              <span
                v-for="index in Math.floor(clothing?.rating)"
                style="color: #ffed00"
                >★</span
              >
              <span v-for="index in 5 - Math.floor(clothing?.rating)">★</span>
            </div>
            <p>{{ clothing?.rating }}</p>
          </div>
          <div class="clothingFeatures">
            <ul>
              <li>Type: {{ clothing?.type }}</li>
              <li v-if="clothing?.gender">Gender: Men</li>
              <li v-else>Gender: Women</li>
              <li>Colour: {{ clothing?.color }}</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 clothingImg">
        <img v-bind:src="clothing?.img" alt="clothing" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="clothingOtherFeatures">
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
            <p class="inStock" v-if="clothing?.quantity > 0">In Stock</p>
            <p class="outOfStock" v-else>Out of Stock</p>
            <p class="deliveryTime" v-if="clothing?.quantity > 0">
              Deliverytime 5 - 6 days. <br />
              Delivery between {{ deliveryTime() }}
            </p>
            <p><b>Quantity</b></p>
            <div class="quantityCounter">
              <button @click="decrementAmount">
                <img src="../img/minus-icon.svg" />
              </button>
              <input type="number" v-model="clothingAmount" />
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
        <div class="clothingDescription">
          <h5>Description</h5>
          <p class="clothingDescName">
            {{ clothing?.brand }} <br />
            {{ clothing?.name }}
          </p>
          <p>{{ clothing?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarClothingsWrapper">
          <h5>Similar Products</h5>
          <div class="row simillarClothings">
            <div
              class="col-4 similarClothing"
              v-for="clothing in simillarClothings"
            >
              <router-link
                :to="getClothingLink(clothing.id)"
                style="color: black; text-decoration: none"
              >
                <div class="card">
                  <img
                    v-bind:src="clothing?.img"
                    class="card-img-top"
                    alt="clothing"
                  />
                  <div class="card-body">
                    <p class="card-text">
                      <b>{{ clothing?.brand }}</b> <br />
                      {{ clothing?.name }}
                    </p>
                    <div class="simillarClothingPrice">
                      <span v-if="clothing?.salePrice === 0"
                        ><b>€ {{ clothing?.price }}</b></span
                      >
                      <span v-else>
                        <b>€ {{ clothing?.salePrice }}</b>
                        <del>€ {{ clothing?.price }}</del>
                      </span>
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
                      </div>
                      <p>{{ clothing?.rating }}</p>
                    </div>
                    <div class="simillarClothingRating" v-else></div>
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

// creates link for single clothing
const getClothingLink = (id) => {
  return `/clothing/${id}`;
};

// loads clothing and simillar clothing state
const processClothingState = () => {
  // set clothing
  clothing.value = clothingItems.value.find((c) => c.id === Number(props.id));

  // set simillar clothings
  simillarClothings.value = getSimillarClothings();
};

onMounted(() => {
  processClothingState();
});

// add item to cart
const addToCart = () => {
  store.addToShoppingCart({
    item: clothing.value,
    amount: clothingAmount.value,
  });
  clothingAmount.value = 1;
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

.clothingSection1 {
  margin-top: 55px;
  .clothingName {
    h4 {
      font-weight: 700;
      color: #424242;
    }

    #clothingTitle {
      font-size: 20px;
    }

    .itemNo {
      font-size: 14px;
      margin-top: 0px;
      margin-bottom: -3px;
    }

    .clothingRating {
      @include displayFlex(row);
      align-items: center;

      .clothingWrapper {
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

    .clothingFeatures {
      margin-top: 50px;

      ul {
        li {
          list-style-image: url("../img/list-ball-grey.svg");
          margin-bottom: 10px;
        }
      }
    }
  }

  .clothingImg {
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

  .clothingOtherFeatures {
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
    .clothingSize {
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

.clothingDescription,
.simillarClothingsWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.clothingDescription {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .clothingDescName {
    font-size: 20px;
    font-weight: 600;
  }
}

.simillarClothingsWrapper {
  h5 {
    background-color: #fafafa;
    padding: 14px 10px;
    border: 1px solid #e0e0e0;
    margin-bottom: 20px;
  }

  .simillarClothings {
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

        .simillarClothingPrice {
          del {
            padding-left: 15px;
            color: grey;
          }
        }

        .simillarClothingRating {
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
