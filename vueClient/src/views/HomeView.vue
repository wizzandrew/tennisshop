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
    <div class="featuresBlock">
      <div class="row">
        <div class="featureHolder">
          <img src="../img/feature-star.svg" class="img-fluid" />
          <p>
            Advantage <br />
            Tennis-Shop
          </p>
        </div>

        <div class="featureHolder">
          <img src="../img/feature-van.svg" class="img-fluid" />
          <p>
            Free delivery <br />
            over 150 €
          </p>
        </div>

        <div class="featureHolder">
          <img src="../img/feature-return.svg" class="img-fluid" />
          <p>
            30 days <br />
            return policy
          </p>
        </div>

        <div class="featureHolder">
          <img src="../img/feature-banknote.svg" class="img-fluid" />
          <p>
            Secure <br />
            payment methods
          </p>
        </div>

        <div class="featureHolder">
          <img src="../img/feature-secure.svg" class="img-fluid" />
          <p>
            Secure <br />
            shopping
          </p>
        </div>
      </div>
    </div>
    <div class="cardsBlock">
      <div class="cardsCombined">
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">Secure payment methods</h5>
            <div class="paymentMethods">
              <img src="../img/cards-klarna.svg" alt="klarna" />
              <img src="../img/cards-americanexpress.svg" alt="amex" />
              <img src="../img/cards-visa.svg" alt="visa" />
              <img src="../img/cards-master.svg" alt="master" />
              <img src="../img/cards-paypal.svg" alt="paypal" />
            </div>
          </div>
        </div>
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">Our shipping service providers</h5>
            <div class="shippingProviders">
              <img src="../img/cards-postnord.svg" alt="postnord" />
              <img src="../img/cards-gls.svg" alt="gls" />
              <img src="../img/cards-dhl.svg" alt="dhl" />
              <img src="../img/cards-ups.svg" alt="ups" />
            </div>
          </div>
        </div>
      </div>
      <div class="card contactCard">
        <div class="card-body">
          <h5 class="card-title">Contact</h5>
          <p class="contactTelephone">
            <u>+45 71 49 35 25</u> <br />
            Mo-Fr 9am to 12pm and 1pm to 5pm <br />
            <u>info@tennis-shop.com</u>
          </p>
          <p class="contactAddress">
            Tennis-Shop GmbH <br />
            Andersen-Str. 18-A <br />
            7400 Herning <br />
            Denmark
          </p>
          <button class="btn btnContact">Contact</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, onMounted, onUpdated } from "vue";
import { storeToRefs } from "pinia";
import { shopStore } from "../stores/shop";
import * as api from "../shared/api.mjs";
import NewArrivalsSlider from "../components/NewArrivalsSlider.vue";
import TopSellersSlider from "../components/TopSellersSlider.vue";

// pinia
const store = shopStore();

//onMounted
onMounted(async () => {
  try {
    const arrivals = await api.getNewArrivals();
    if (arrivals !== undefined && arrivals !== null) {
      store.setNewArrivals(arrivals);
      console.log("new arrivals ", arrivals);
    }
  } catch (error) {
    console.log(error);
  }

  try {
    const sellers = await api.getTopSellers();
    if (sellers !== undefined && sellers !== null) {
      store.setTopSellers(sellers);
      console.log("top sellers ", sellers);
    }
  } catch (error) {
    console.log(error);
  }

  // console.log("home mounted", newArrivalItems);
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
      height: 85.1875vh;
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

.featuresBlock {
  background-color: #444444;
  margin-bottom: 50px;

  .row {
    @include displayFlex(row);

    .featureHolder {
      display: flex;
      justify-content: center;
      align-items: center;
      height: 40px;
      width: 20%;
      font-size: 12px;
      color: white;

      p {
        margin: 0;
      }

      img {
        height: 19px;
        width: auto;
        padding: 0 10px;
      }

      &:hover {
        background-color: #ded11e;
        // opacity: 0.9;
        color: black;
      }
    }
  }
}

.cardsBlock {
  margin-bottom: 100px;
  @include displayFlex(row);
  justify-content: space-between;

  .cardsCombined {
    width: 52.5%;
    @include displayFlex(column);
    justify-content: space-between;
  }

  .card {
    .card-body {
      padding: 0;

      .card-title {
        font-size: 16px;
        font-weight: 600;
        background-color: #e0e0e0;
        padding: 5px 10px;
        height: 30px;
      }

      .paymentMethods,
      .shippingProviders {
        padding: 10px 0;
      }

      img {
        width: 95px;
        height: auto;
        padding: 10px 15px;
      }

      .contactTelephone {
        font-size: 14px;
        padding: 0 10px;
      }

      .contactAddress {
        font-size: 12px;
        padding: 0 10px;
        margin: 0;
      }
    }
  }

  .contactCard {
    width: 45%;
    display: flex;

    .card-body {
      @include displayFlex(column);
      background-color: #fafafa;

      .btnContact {
        display: flex;
        background-color: $theYellow;
        align-self: flex-end;
        margin: 10px;

        &:hover {
          background-color: #dcce10;
        }
      }
    }
  }
}
</style>
