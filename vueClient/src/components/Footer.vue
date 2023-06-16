<template>
  <div className="footerHolder">
    <div className="container footerContainer">
      <div className="row socialHolder">
        <div className="footer-social">
          <h4>Tennis Shop</h4>
          <div className="footer-social-links">
            <img src="../img/footer-facebook.png" alt="facebook" />
            <img src="../img/footer-browser.png" alt="browser" />
            <img src="../img/footer-instagram.png" alt="instagram" />
          </div>
        </div>
        <hr />
      </div>
      <div className="row">
        <div className="footer-info">
          <div className="footer-info-holder">
            <div className="footer-info-element">Terms of use</div>
            <div className="footer-info-element">About us</div>
            <div className="footer-info-element">Privacy Policy</div>
          </div>

          <div className="footer-info-holder">
            <div className="footer-info-element">Cookies</div>
            <div className="footer-info-element">Help & Service</div>
            <div className="footer-info-element">Stores</div>
          </div>

          <div className="footer-info-holder">
            <div className="footer-info-element">Payment methods</div>
            <div className="footer-info-element">Delivery costs</div>
            <div className="footer-info-element">Return / refund</div>
          </div>
        </div>
      </div>
      <div className="row footer-copyright col-12">
        <div>
          <span className="copyrightSpan">Copyright © 2023 TS.</span> By
          subscribing to the Tennis-Shop Newsletter you give consent to
          Tennis-Shop GmbH contacting you by electronic mail for the purpose of
          general advertising.
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss">
.footerHolder {
  background-color: #616161;
  color: #fff;
  font-family: "BBC Reith Sans", "Arial", "Helvetica", freesans, sans-serif,
    sans-serif;
  font-size: 14px;
  padding: 30px 0 20px 0;
}

.footerContainer {
  padding-left: 28px;
}

.socialHolder {
  margin-bottom: 20px;

  hr {
    max-width: 994px;
    margin-left: 13px;
    margin-top: 10px;
  }
}

.footer-social {
  display: flex;
  align-items: center;
  font-size: 22px;

  h4 {
    margin-bottom: 0;
    padding-right: 20px;
  }

  .footer-social-links img {
    width: 30%;
    padding-right: 10px;

    &:hover {
      opacity: 0.8;
    }
  }
}

.footer-info {
  display: flex;
  margin-bottom: 15px;

  .footer-info-holder {
    display: flex;
  }

  .footer-info-element {
    padding-right: 20px;

    &:hover {
      text-decoration: underline;
    }
  }
}

.copyrightSpan {
  font-weight: 600;
}

/********MEDIA****QUERIES************/

@media (max-width: 1200px) {
  .footer-info-holder {
    flex-direction: column;
    margin-right: 150px;
  }

  .footer-info-element {
    padding-bottom: 20px;
  }
}

@media (max-width: 992px) {
  .footer-info-holder {
    margin-right: 80px;
  }
}

@media (max-width: 768px) {
  .footer-info-holder {
    margin-right: 30px;
  }

  .footer-info-element {
    padding-bottom: 15px;
  }
}

@media (max-width: 576px) {
  .footer-social {
    flex-direction: column;
    align-items: flex-start;
  }

  .footer-social-links {
    padding-top: 5px;
  }

  .footer-info {
    flex-direction: column;
  }

  .footer-info-element {
    padding-bottom: 10px;
  }
}
</style>
