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
      <div>My Cart</div>
      <div v-if="shoppingCart?.length === 1">
        {{ shoppingCart?.length }} item in shopping cart
      </div>
      <div v-else>{{ shoppingCart?.length }} items in shopping cart</div>
    </div>
    <div class="row shoppingItems">
      <div class="col-12 shoppingItemsWrapper" v-if="shoppingCart?.length > 0">
        <div class="col-3 offset-1"><h5>Article</h5></div>
        <div class="col-2"><h5>Size</h5></div>
        <div class="col-3"><h5>Quantity</h5></div>
        <div class="col-1"><h5>Price</h5></div>
        <div class="col-1"><h5>Total</h5></div>
        <div class="col-1"><h5>Remove</h5></div>
      </div>

      <hr />

      <div class="col-12 shoppingItem" v-for="article in shoppingCart">
        <div class="col-4 shoppingArticle">
          <img v-bind:src="article.item.img" alt="item" />
          <div class="articleName">
            <span>{{ article.item.brand }}</span>
            <span
              ><b>{{ article.item.name }}</b></span
            >
          </div>
        </div>
        <div class="col-2 shoppingArticleSize">
          <span v-if="article.item.size !== undefined">{{
            article.item.size
          }}</span>
          <span v-else>{{ article.item.gripSize }}</span>
        </div>
        <div class="col-3 shoppingArticleAmount">{{ article.amount }}</div>
        <div class="col-1 shoppingArticlePrice">
          <span v-if="article.item.salePrice === 0"
            ><b>€ {{ article.item.price }}</b></span
          >
          <span v-else
            ><del>€ {{ article.item.price }}</del> <br />
            <b>€ {{ article.item.salePrice }}</b></span
          >
        </div>
        <div class="col-1">
          <span v-if="article.item.salePrice === 0"
            >€ {{ article.item.price * article.amount }}</span
          >
          <span v-else>€ {{ article.item.salePrice * article.amount }}</span>
        </div>
        <div class="col-1">
          <button
            class="btn btn-secondary"
            @click="removeShopItem(article.item.id)"
          >
            x
          </button>
        </div>
      </div>
    </div>
    <div class="row cartFinalInfo">
      <div class="col-12 order-last col-md-6 order-md-first">
        <div class="col cartDelivery">
          <h5>Delivery</h5>
          <p>Delivery time: 5 - 6 days.</p>
        </div>
        <div class="col cartPayment">
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
        </div>
      </div>
      <div class="col-12 order-first col-md-6 order-md-last">
        <div class="cartTotal">
          <p>Total products (incl. tax) € {{ cartTotal }}</p>
          <p>Shipping costs € 0.00</p>
        </div>
        <div class="cartGrandTotal">
          <p>Grand total (incl. VAT) € {{ cartTotal }}</p>
        </div>
        <router-link
          to="/cartUserInfo"
          style="color: black; text-decoration: none"
        >
          <button class="btn btn-success">Go to checkout</button>
        </router-link>
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

// calculate shppings cart total
const cartTotal = computed(() => {
  let total = 0;

  shoppingCart.value?.forEach((s) => {
    const price = s.item.salePrice === 0 ? s.item.price : s.item.salePrice;
    total = total + price * s.amount;
  });
  return total;
});

const removeShopItem = (id) => {
  store.removeFromShoppingCart(id);
};
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
  @include displayFlex(row);
  justify-content: space-between;
  margin-top: 30px;
  background-color: #e0e0e0;

  div {
    width: fit-content;
  }
}

.shoppingItems {
  margin-top: 50px;
  margin-bottom: 30px;
  .shoppingItemsWrapper {
    @include displayFlex(row);
  }

  .shoppingItem {
    @include displayFlex(row);
    align-items: center;
    border-bottom: 1px rgb(187, 187, 187) solid;
    padding: 5px 0;
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

.cartFinalInfo {
  .cartDelivery {
    background-color: #fafafa;
    margin-bottom: 50px;
    padding: 10px 0 30px 10px;
  }

  .cartPayment {
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

        .paymentMethods {
          padding: 10px 0;
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
