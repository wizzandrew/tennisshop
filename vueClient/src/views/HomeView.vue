<template>
  <div class="carouselHolder">
    <div id="carouselIndicators" class="carousel slide" data-bs-ride="carousel">
      <div class="carousel-indicators">
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="0"
          class="active"
          aria-current="true"
          aria-label="Slide 1"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="1"
          aria-label="Slide 2"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="2"
          aria-label="Slide 3"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="3"
          aria-label="Slide 4"
        ></button>
        <button
          type="button"
          data-bs-target="#carouselIndicators"
          data-bs-slide-to="4"
          aria-label="Slide 5"
        ></button>
      </div>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img
            src="../img/carousel-img1.png"
            class="d-block w-100"
            alt="img1"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img2.png"
            class="d-block w-100"
            alt="img2"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img3.png"
            class="d-block w-100"
            alt="img3"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img4.png"
            class="d-block w-100"
            alt="img4"
          />
        </div>
        <div class="carousel-item">
          <img
            src="../img/carousel-img5.png"
            class="d-block w-100"
            alt="img5"
          />
        </div>
      </div>
      <button
        class="carousel-control-prev"
        type="button"
        data-bs-target="#carouselIndicators"
        data-bs-slide="prev"
      >
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button
        class="carousel-control-next"
        type="button"
        data-bs-target="#carouselIndicators"
        data-bs-slide="next"
      >
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
  </div>

  <div class="container">
    <div class="newArrivalsHeading">
      <h2><span>NEW ARRIVALS</span></h2>
    </div>
  </div>

  <div class="underLine"></div>

  <div class="container">
    <NewArrivalsSlider />
  </div>

  <div class="container">
    <div class="topSellersHeading">
      <h2><span>TOP SELLERS</span></h2>
    </div>
  </div>

  <div class="underLine"></div>

  <div class="container">
    <TopSellersSlider />
  </div>

  <div class="serviceContainer">
    <div class="serviceImg"></div>
  </div>

  <div class="container">
    <div class="serviceHeading">
      <h2><span>SERVICE WORLD</span></h2>
    </div>
    <div class="serviceIcons">
      <div class="row">
        <!-- first part -->
        <div class="col-2"></div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img
              src="../img/service-racket.svg"
              class="img-fluid"
              alt="racket"
            />
          </div>
          <p>Racket Advisor</p>
        </div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img
              src="../img/service-strings.png"
              class="img-fluid"
              alt="strings"
            />
          </div>
          <p>String Advisor</p>
        </div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img src="../img/service-team.svg" class="img-fluid" alt="team" />
          </div>
          <p>Teamwear</p>
        </div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img
              src="../img/service-airplane.svg"
              class="img-fluid"
              alt="airplane"
            />
          </div>
          <p>Tennis Travel</p>
        </div>
        <div class="col-2"></div>
        <!-- first part -->

        <!-- second part -->
        <div class="col-2"></div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img
              src="../img/service-package.svg"
              class="img-fluid"
              alt="package"
            />
          </div>
          <p>Return Info</p>
        </div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img src="../img/service-info.svg" class="img-fluid" alt="info" />
          </div>
          <p>Service Center</p>
        </div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img
              src="../img/service-professional.svg"
              class="img-fluid"
              alt="professional"
            />
          </div>
          <p>Professionals</p>
        </div>
        <div class="col-3 col-md-2 serviceIcon">
          <div class="imgHolder">
            <img src="../img/service-shoe.svg" class="img-fluid" alt="shoe" />
          </div>
          <p>Shoe Finder</p>
        </div>
        <div class="col-2"></div>
        <!-- second part -->
      </div>
    </div>
    <BottomPage />
  </div>
</template>

<script setup>
import { ref, computed, onMounted, onUpdated } from "vue";
import { storeToRefs } from "pinia";
import { shopStore } from "../stores/shop";
import * as api from "../shared/api.mjs";
import NewArrivalsSlider from "../components/NewArrivalsSlider.vue";
import TopSellersSlider from "../components/TopSellersSlider.vue";
import BottomPage from "../components/BottomPage.vue";

// pinia
const store = shopStore();

//onMounted
onMounted(async () => {
  //fetching shop items
  try {
    const shopitems = await api.getShopItems();
    if (shopitems !== undefined && shopitems !== null) {
      store.setShopItems(shopitems);
      console.log("shop items ", shopitems);
    }
  } catch (error) {
    console.log(error);
  }

  //fetching new arrivals
  try {
    const arrivals = await api.getNewArrivals();
    if (arrivals !== undefined && arrivals !== null) {
      store.setNewArrivals(arrivals);
      console.log("new arrivals ", arrivals);
    }
  } catch (error) {
    console.log(error);
  }

  //fetching top sellers
  try {
    const sellers = await api.getTopSellers();
    if (sellers !== undefined && sellers !== null) {
      store.setTopSellers(sellers);
      console.log("top sellers ", sellers);
    }
  } catch (error) {
    console.log(error);
  }
});

// onUpdated(() => {
//   console.log("home updated", newArrivalItems);
// });
</script>

<style lang="scss">
@import "../assets/_sass";

.carousel {
  .carousel-inner {
    img {
      height: 81vh;
      width: 100%;
      object-fit: cover;
    }
  }
}

.newArrivalsHeading {
  padding-top: 75px;

  h2 {
    font-weight: 600;
    font-size: 1.8rem;
    letter-spacing: 2px;
    margin: 0;

    span {
      border-bottom: 3px solid $theRed;
    }
  }
}

.underLine {
  border-bottom: 3px solid #eee;
  margin-bottom: 30px;
}

.topSellersHeading {
  padding-top: 100px;

  h2 {
    font-weight: 600;
    font-size: 1.8rem;
    letter-spacing: 2px;
    margin: 0;

    span {
      border-bottom: 3px solid $theYellow;
    }
  }
}

.serviceContainer {
  margin-top: 100px;
  background-color: #f5f5f5;

  .serviceImg {
    width: 80%;
    height: 275px;
    margin: 0 auto;
    background-image: url("../img/service-banner.jpg");
    background-size: cover;
    background-repeat: no-repeat;
  }
}

.serviceHeading {
  position: relative;

  h2 {
    font-weight: 600;
    font-size: 1.8rem;
    letter-spacing: 2px;

    span {
      position: absolute;
      top: -61px;
      background-color: white;
      padding: 8px;
      border-bottom: 3px solid $theBlue;
    }
  }
}

.serviceIcons {
  padding-top: 50px;
  padding-bottom: 50px;

  .serviceIcon {
    @include displayFlex(column);
    justify-content: center;
    align-items: center;

    .imgHolder {
      background-color: #f5f5f5;
      padding: 20px;
      border-radius: 100px;

      img {
        background-color: #f5f5f5;
      }
    }

    p {
      font-size: 14px;
      font-weight: 600;
      padding: 10px 0 20px 0;
    }
  }
}
</style>
