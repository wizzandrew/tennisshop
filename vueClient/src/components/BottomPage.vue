<template>
  <div>
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
<script></script>
<style lang="scss">
@import "../assets/_sass";

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
