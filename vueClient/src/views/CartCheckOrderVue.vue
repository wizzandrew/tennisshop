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
      <div>Check & Order Summary</div>
    </div>
    <div class="row cartSummary">
      <div class="col-12 col-md-7 shoppingItems">
        <div
          class="col-12 shoppingItemsWrapper"
          v-if="shoppingCart?.length > 0"
        >
          <div class="col-4 offset-1">Article</div>
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
            <div>
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
            <h5 class="card-title">Preferred payment method</h5>
            <div class="paymentMethods">
              <img src="../img/cards-americanexpress.svg" alt="amex" />
              <img src="../img/cards-visa.svg" alt="visa" />
              <img src="../img/cards-master.svg" alt="master" />
            </div>
          </div>
        </div>
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">InvoiceAmount</h5>
            <div>
              <p>
                Subtotal €{{ cartTotal }} <br />
                Shipping €19.99
              </p>
              <p><b>Total</b> €{{ cartTotal + 19.99 }}</p>
              <button class="btn btn-success">Buy now</button>
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
</script>

<style lang="scss">
@import "../assets/sass";

.headerHolder {
  display: none;
}

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

.cartSummary {
  margin-top: 50px;
  margin-bottom: 30px;
  .shoppingItems {
    .shoppingItemsWrapper {
      @include displayFlex(row);
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
      }
    }
  }
}
</style>
