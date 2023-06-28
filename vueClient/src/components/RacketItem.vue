<template>
  <div class="container" v-if="racket != undefined">
    <div class="row">
      <div class="col-12 col-md-6 col-lg-4">
        <div class="racketInfo1">
          <h5>{{ racket?.brand }}</h5>
          <span>{{ racket?.name }}</span>
          <div>
            <span
              v-for="index in Math.floor(racket?.rating)"
              style="color: #ffed00"
              >★</span
            >
            <span v-for="index in 5 - Math.floor(racket?.rating)">★</span>
            <span>{{ racket?.rating }}</span>
          </div>
          <div class="racketInfo2">
            <ul>
              <li>Head size {{ racket?.headSize }}cm<sup>2</sup></li>
              <li>Weight {{ racket?.weight }}g</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-lg-4 racketImg">
        <img v-bind:src="racket?.img" alt="racket" />
      </div>
      <div class="col-12 col-md-6 col-lg-4">
        <div class="racketInfo3">
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
            <p v-if="racket?.quantity > 0">In Stock</p>
            <p v-else>Out of Stock</p>
            <p><b>Quantity</b></p>
            <button @click="decrementAmount">-</button>
            <input type="number" v-model="racketAmount" />
            <button @click="incrementAmount">+</button>
          </div>
          <button class="btn btn-success">Add to cart</button>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col col-md-6">
        <div class="racketDescription">
          <h5>Description</h5>
          <p>{{ racket?.brand }} {{ racket?.name }}</p>
          <p>{{ racket?.description }}</p>
        </div>
      </div>
      <div class="col col-md-6">
        <div class="simillarRacketsWrapper">
          <h5>Similar</h5>
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
                      <b>{{ racket?.brand }}</b> {{ racket?.name }}
                    </p>
                    <div class="simillarRacketPrice">
                      <span v-if="racket?.salePrice === 0"
                        ><b>€ {{ racket?.price }}</b></span
                      >
                      <span v-else
                        ><del>€ {{ racket?.price }}</del> <br />
                        <b>€ {{ racket?.salePrice }}</b></span
                      >
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
                        <span>{{ racket?.rating }}</span>
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

onUpdated(() => {
  processRacketState();
});
</script>

<style lang="scss">
@import "../assets/sass";

.racketInfo1 {
  .racketInfo2 {
    margin-top: 50px;
  }
}

.racketImg {
  img {
    height: 500px;
    width: 100%;
    object-fit: cover;
  }
}

.racketInfo3 {
  .gripSize {
    padding: 50px 0;
    button {
      margin-right: 10px;
    }
  }

  .btn-success {
    margin-top: 20px;
  }
}

.racketDescription,
.simillarRacketsWrapper {
  padding-top: 100px;
  padding-bottom: 100px;
}

.simillarRacketsWrapper {
  .simillarRackets {
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
