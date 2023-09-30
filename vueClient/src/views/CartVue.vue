<template>
  <div class="container">
    <div class="row cartHeader">
      <div class="col-3 cartNav">
        <a href="/">
          <img src="../img/tennisshop-logo.svg" alt="brand" />
        </a>
      </div>
      <div class="col-5 offset-4 cartSteps">
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
      <div class="cartName">My Cart</div>
      <div class="cartQuantity" v-if="shoppingCart?.length === 1">
        ({{ shoppingCart?.length }} item in shopping cart)
      </div>
      <div class="cartQuantity" v-else>
        ({{ shoppingCart?.length }} items in shopping cart)
      </div>
    </div>
    <div class="row shoppingItems">
      <div class="col-12 shoppingItemsWrapper" v-if="shoppingCart?.length > 0">
        <div class="col-4"><h6>Article</h6></div>
        <div class="col-2"><h6>Size</h6></div>
        <div class="col-3"><h6>Quantity</h6></div>
        <div class="col-1"><h6>Price</h6></div>
        <div class="col-1"><h6>Total</h6></div>
        <div class="col-1"><h6>Remove</h6></div>
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
          <h6>Delivery</h6>
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
      <div
        class="col-12 order-first col-md-6 order-md-last cartTotalCalculation"
      >
        <div class="cartTotal">
          <div>
            <span>Total products (incl. tax)</span>
            <span>€ {{ cartTotal }}</span>
          </div>
          <div>
            <span>Shipping costs</span>
            <span>€ 0</span>
          </div>
        </div>
        <div class="cartGrandTotal">
          <span
            ><span id="headerGrandTotal">Grand total</span> <br />
            (incl. VAT)</span
          >
          <span id="headerCartTotal">€ {{ cartTotal }}</span>
        </div>
        <div class="cartGoToCheckout">
          <router-link
            to="/cartUserInfo"
            style="color: black; text-decoration: none"
          >
            <button class="btn btn-success">Go to checkout</button>
          </router-link>
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

.cartHeader {
  margin-top: 30px;

  .cartNav {
    padding-left: 0;
  }

  .cartSteps {
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

      &:nth-child(2),
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

  .cartQuantity {
    font-size: 14px;
  }
}

.shoppingItems {
  margin-top: 50px;
  margin-bottom: 30px;
  .shoppingItemsWrapper {
    @include displayFlex(row);

    div h6 {
      font-weight: bold;
    }

    div {
      &:first-child {
        h6 {
          margin-left: 73px;
        }
      }
    }
  }

  .shoppingItem {
    @include displayFlex(row);
    align-items: center;
    border-bottom: 1px rgb(187, 187, 187) solid;
    padding: 5px 0;
    margin-bottom: 10px;

    .shoppingArticle {
      @include displayFlex(row);
      align-items: center;

      .articleName {
        @include displayFlex(column);
        padding-left: 10px;
      }

      img {
        width: 85px;
        height: 85px;
      }
    }

    .btn-secondary {
      padding-top: 0;
      color: #444444;
      background-color: white;
      border: none;
      font-weight: 900;
      font-size: 22px;
    }
  }
}

.cartFinalInfo {
  .cartDelivery {
    background-color: #fafafa;
    margin-bottom: 60px;
    padding: 10px 0 30px 10px;
    border: 1px solid #eee;

    h6 {
      font-weight: bold;
    }

    p {
      font-size: 14px;
    }
  }

  .cartPayment {
    .card {
      border: 0;
      .card-body {
        padding: 0;

        .card-title {
          font-size: 16px;
          font-weight: 600;
          background-color: #e0e0e0;
          padding: 10px 10px;
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

  .cartTotalCalculation {
    .cartTotal,
    .cartGrandTotal,
    .cartGoToCheckout {
      margin-left: 100px;
    }

    .cartTotal {
      div {
        display: flex;
        justify-content: space-between;
        margin-bottom: 15px;
      }
    }

    .cartGrandTotal {
      display: flex;
      justify-content: space-between;
      background-color: #fafafa;
      border: 1px solid #eee;
      padding: 7px 10px;
      margin-bottom: 20px;

      #headerGrandTotal {
        font-size: 20px;
        font-weight: 700;
      }

      #headerCartTotal {
        font-size: 24px;
        font-weight: 700;
        text-decoration: underline;
      }
    }

    .cartGoToCheckout {
      display: flex;
      justify-content: flex-end;

      .btn-success {
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
