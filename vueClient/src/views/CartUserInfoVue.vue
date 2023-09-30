<template>
  <div class="container">
    <div class="row cartHeader">
      <div class="col-3 cartNav">
        <a href="/">
          <img src="../img/tennisshop-logo.svg" alt="brand" />
        </a>
      </div>
      <div class="col-5 offset-4 cartSteps2">
        <div class="col-3 cartStep">
          <span>1</span>
          <p>Cart</p>
        </div>
        <div class="col-5 cartStep">
          <span>2</span>
          <p>My data & Payment</p>
        </div>
        <div class="col-4 cartStep">
          <span>3</span>
          <p>Check & Order</p>
        </div>
      </div>
    </div>
    <div class="row cartHeading">
      <div class="cartName">My Payment & Address</div>
    </div>
    <div class="row cartPaymentAdress">
      <div class="col-12 col-md-6 cartPayment">
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">Select payment method</h5>
            <div class="paymentMethods">
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="paypalCheckbox"
                  disabled
                />
                <label class="form-check-label" for="paypalCheckbox">
                  PayPal
                </label>
                <img src="../img/cards-paypal.svg" alt="paypal" />
              </div>

              <div class="form-check">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value="true"
                  id="debitCardCheckbox"
                  disabled
                  checked
                />
                <label class="form-check-label" for="debitCardCheckbox">
                  Debit Card
                </label>
                <img src="../img/cards-americanexpress.svg" alt="amex" />
                <img src="../img/cards-visa.svg" alt="visa" />
                <img src="../img/cards-master.svg" alt="master" />
              </div>

              <div class="userPaymentMethod">
                <div class="paymentWrapper">
                  <p>
                    Last 4 digits:
                    {{ user?.paymentMethod.number.toString().substr(-4) }}
                  </p>
                  <div class="paymentMethodInfo">
                    <div>
                      <span>Name: </span>
                      <span>{{ user?.name }}</span>
                    </div>
                    <div>
                      <span>Valid through: </span>
                      <span>{{ user?.paymentMethod.valid.slice(5, 10) }}</span>
                    </div>
                    <img src="../img/cards-master2.png" alt="master" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 cartAddress">
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">Shipping Address</h5>
            <div>
              <p id="cartAdressWrapper">
                {{ user?.name }} <br />
                {{ user?.address.street }}, {{ user?.address.apartmentNo }}
                <br />
                {{ user?.address.postalCode }} {{ user?.address.city }} <br />
                {{ user?.address.country }}
              </p>
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
        <router-link
          to="/cartCheckOrder"
          style="color: black; text-decoration: none"
        >
          <button class="btn btn-success">Check & Order</button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script setup>
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";

// pinia
const store = shopStore();

const { user } = storeToRefs(store);
</script>

<style lang="scss">
@import "../assets/sass";

.cartHeader {
  margin-top: 30px;

  .cartNav {
    padding-left: 0;
  }

  .cartSteps2 {
    @include displayFlex(row);

    .cartStep {
      @include displayFlex(row);
      justify-content: flex-start;
      align-items: center;
      background-color: #e0e0e0;

      span {
        margin-right: 10px;
        margin-left: 20px;
        width: 30px;
        padding-top: 5px;
        height: 30px;
        background-color: white;
        border-radius: 50%;
        text-align: center;
        font-size: 14px;
        font-weight: bold;
      }

      p {
        margin: 0;
        font-size: 14px;
        font-weight: bold;
      }

      &:first-child,
      &:nth-child(3) {
        background-color: #f5f5f5;
        opacity: 0.7;
      }
    }
  }
}

.cartHeading {
  @include displayFlex(row);
  justify-content: space-between;
  margin-top: 30px;
  padding: 10px 0;
  background-color: #e0e0e0;

  div {
    width: fit-content;
  }

  .cartName {
    font-size: 16px;
    font-weight: bold;
  }
}

.cartPaymentAdress {
  margin-top: 50px;
  margin-bottom: 100px;

  img {
    width: 95px;
    height: auto;
    padding: 10px 15px;
  }

  .card {
    border: 0;
    .card-body {
      padding: 0;

      .card-title {
        font-size: 16px;
        font-weight: 600;
        background-color: #e0e0e0;
        padding: 5px 10px;
        height: 30px;
        margin-bottom: 0;
      }
    }
  }

  .cartPayment {
    padding-left: 0;

    .paymentMethods {
      border: 1px solid #eee;
      padding: 5px 0 27px 10px;
      .form-check {
        display: flex;
        align-items: center;

        label {
          margin-left: 10px;
        }
      }

      .userPaymentMethod {
        margin-top: 20px;

        .paymentWrapper {
          max-width: 310px;
          min-width: 250px;
          background-image: linear-gradient(
            rgb(172, 190, 224),
            rgb(83, 133, 225)
          );
          border-radius: 5px;
          color: white;
          padding: 10px 10px 0 10px;

          .paymentMethodInfo {
            @include displayFlex(column);

            img {
              display: flex;
              align-self: flex-end;
              padding: 0;
            }
          }
        }
      }
    }
  }

  .cartAddress {
    #cartAdressWrapper {
      border: 1px solid #eee;
      padding: 5px 0 10px 10px;
    }

    .shippingProviders {
      border: 1px solid #eee;
      padding: 5px 0 10px 10px;
    }

    a {
      display: flex;
      justify-content: flex-end;

      .btn-success {
        margin-top: 12px;
        width: 200px;
        height: 45px;
        border-radius: 0;
        background-color: #cee28e;
        border: none;
        font-size: 18px;
        font-weight: 600;
      }
    }
  }
}
</style>
