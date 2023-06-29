<template>
  <div class="container">
    <div class="row cartHeader">
      <div class="col-3">
        <a href="/">
          <img src="../img/tennisshop-logo.svg" alt="brand" />
        </a>
      </div>
      <div class="col-6 offset-3 cartSteps">
        <div class="col-4 cartStep"><p>Cart</p></div>
        <div class="col-4 cartStep"><p>My data & Payment</p></div>
        <div class="col-4 cartStep"><p>Check & Order</p></div>
      </div>
    </div>
    <div class="row cartHeading">
      <div>My Payment & Address</div>
    </div>
    <div class="row cartPaymentAdress">
      <div class="col-12 col-md-6">
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
                    <span>Valid till: </span>
                    <span>{{ user?.paymentMethod.valid.slice(5, 10) }}</span>
                  </div>
                  <img src="../img/cards-master.svg" alt="master" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6">
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">Shipping Address</h5>
            <div>
              <p>{{ user?.address.street }}, {{ user?.address.apartmentNo }}</p>
              <p>{{ user?.address.postalCode }} {{ user?.address.city }}</p>
              <p>{{ user?.address.country }}</p>
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
        <button class="btn btn-success">Check & Order</button>
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
console.log(user);
</script>

<style lang="scss">
@import "../assets/sass";

.cartHeader {
  .cartSteps {
    @include displayFlex(row);

    .cartStep {
      @include displayFlex(row);
      justify-content: center;
      align-items: center;
      background-color: #e0e0e0;

      p {
        margin: 0;
      }
    }

    .cartStep::after {
      content: " ";
      width: 0;
      height: 0;
      border-top: 37px solid transparent;
      border-left: 50px solid #c6c6c6;
      border-bottom: 25px solid transparent;
    }
  }
}

.cartHeading {
  margin-top: 30px;
  background-color: #e0e0e0;
}

.cartPaymentAdress {
  margin-top: 75px;
  margin-bottom: 100px;

  .card {
    border: 0;
    .card-body {
      padding: 0;

      .card-title {
        font-size: 16px;
        font-weight: 600;
        background-color: #cbcbcb;
        padding: 5px 10px;
        height: 30px;
      }

      img {
        width: 95px;
        height: auto;
        padding: 10px 15px;
      }

      .paymentMethods {
        .userPaymentMethod {
          background-image: linear-gradient(
            rgb(172, 190, 224),
            rgb(83, 133, 225)
          );
          color: white;
          padding: 10px 10px 0 10px;
          margin-top: 30px;

          img {
            margin-left: 358px;
          }
        }
      }
    }
  }
}
</style>
