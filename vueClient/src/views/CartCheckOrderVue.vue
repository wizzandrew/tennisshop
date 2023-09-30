<template>
  <div class="container">
    <div class="row cartHeader">
      <div class="col-3 cartNav">
        <a href="/">
          <img src="../img/tennisshop-logo.svg" alt="brand" />
        </a>
      </div>
      <div class="col-5 offset-4 cartSteps3">
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
      <div class="cartName">Check & Order Summary</div>
    </div>
    <div class="row cartSummary">
      <div class="col-12 col-md-7 shoppingItems">
        <div
          class="col-12 shoppingItemsWrapper"
          v-if="shoppingCart?.length > 0"
        >
          <div class="col-5"><span>Article</span></div>
          <div class="col-1">Size</div>
          <div class="col-1">Quantity</div>
          <div class="col-1 offset-1">Price</div>
          <div class="col-1 offset-1">Total</div>
        </div>

        <hr />
        <div class="col-12 shoppingItem" v-for="article in shoppingCart">
          <div class="col-5 shoppingArticle">
            <img v-bind:src="article.item.img" alt="item" />
            <div class="articleName">
              <span>{{ article.item.brand }}</span>
              <span
                ><b>{{ article.item.name }}</b></span
              >
            </div>
          </div>
          <div class="col-1 shoppingArticleSize">
            <span v-if="article.item.size !== undefined">{{
              article.item.size
            }}</span>
            <span v-else>{{ article.item.gripSize }}</span>
          </div>
          <div class="col-1 shoppingArticleAmount">{{ article.amount }}</div>
          <div class="col-1 offset-1 shoppingArticlePrice">
            <span v-if="article.item.salePrice === 0"
              ><b>€ {{ article.item.price }}</b></span
            >
            <span v-else
              ><del>€ {{ article.item.price }}</del> <br />
              <b>€ {{ article.item.salePrice }}</b></span
            >
          </div>
          <div class="col-1 offset-1">
            <span v-if="article.item.salePrice === 0"
              >€ {{ article.item.price * article.amount }}</span
            >
            <span v-else>€ {{ article.item.salePrice * article.amount }}</span>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-5 addressPayment">
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">Shipping Address</h5>
            <div class="card-div">
              <p>
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
            <h5 class="card-title">My preferred payment method</h5>
            <div class="card-div paymentMethods">
              <img src="../img/cards-americanexpress.svg" alt="amex" />
              <img src="../img/cards-visa.svg" alt="visa" />
              <img src="../img/cards-master.svg" alt="master" />
            </div>
          </div>
        </div>
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">Invoice Amount</h5>
            <div class="card-div cartInvoiceTotal">
              <div>
                <span>Subtotal</span>
                <span>€{{ cartTotal }}</span>
              </div>
              <div>
                <span>Shipping</span>
                <span>€19.99</span>
              </div>
              <div>
                <span id="invoiceGrandTotal">Grand Total</span>
                <span id="invoiceGrandTotalAmount"
                  >€{{ cartTotal + 19.99 }}</span
                >
              </div>
              <div class="cartBuyNow">
                <router-link to="/" style="color: black; text-decoration: none">
                  <button
                    class="btn btn-success"
                    @click="placeOrder(shoppingCart, cartTotal)"
                  >
                    Buy now
                  </button>
                </router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed } from "vue";
import { shopStore } from "../stores/shop";
import { storeToRefs } from "pinia";
import * as api from "../shared/api.mjs";

const store = shopStore();

const { shoppingCart } = storeToRefs(store);
const { user } = storeToRefs(store);

// calculate shppings cart total
const cartTotal = computed(() => {
  let total = 0;

  shoppingCart.value?.forEach((s) => {
    const price = s.item.salePrice === 0 ? s.item.price : s.item.salePrice;
    total = total + price * s.amount;
  });
  return total;
});

const placeOrder = async (shoppingCart, orderTotal) => {
  // make sure shoppingCart contains shopping items
  if (Array.isArray(shoppingCart) && shoppingCart.length > 0) {
    try {
      const response = await api.postCart(shoppingCart, orderTotal);
      if (response == true) {
        store.setShoppingCart([]);
        console.log("order placed ");
      }
    } catch (error) {
      console.log(error);
    }
  }
};
</script>

<style lang="scss">
@import "../assets/sass";

.cartHeader {
  margin-top: 30px;

  .cartNav {
    padding-left: 0;
  }

  .cartSteps3 {
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

      &:nth-child(1),
      &:nth-child(2) {
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

.cartSummary {
  margin-top: 50px;
  margin-bottom: 30px;

  .shoppingItems {
    .shoppingItemsWrapper {
      @include displayFlex(row);
      font-weight: bold;

      &:first-child {
        span {
          margin-left: 85px;
        }
      }
    }
    .shoppingItem {
      @include displayFlex(row);
      align-items: center;
      border-bottom: 1px rgb(187, 187, 187) solid;
      margin-bottom: 10px;

      .shoppingArticle {
        @include displayFlex(row);

        .articleName {
          @include displayFlex(column);
        }

        img {
          width: 85px;
          height: 85px;
        }
      }
    }
  }

  .addressPayment {
    .card {
      border: 0;
      margin-bottom: 20px;
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

        .card-div {
          border: 1px solid #eee;
          padding: 5px 0 10px 10px;

          p {
            margin-bottom: 0;
          }
        }

        img {
          width: 95px;
          height: auto;
          padding: 10px 15px;
        }
      }
    }

    .cartInvoiceTotal {
      div {
        display: flex;
        justify-content: space-between;
        margin-bottom: 10px;
      }

      #invoiceGrandTotal {
        font-size: 20px;
        font-weight: 700;
      }

      #invoiceGrandTotalAmount {
        font-size: 24px;
        font-weight: 700;
        text-decoration: underline;
      }

      .cartBuyNow {
        display: flex;
        justify-content: flex-end;
        margin-bottom: 0;

        .btn-success {
          width: 200px;
          height: 45px;
          border-radius: 0;
          background-color: #cee28e;
          border: none;
          font-size: 18px;
          font-weight: 600;
          margin: 10px 0 -10px 0;
        }
      }
    }
  }
}
</style>
