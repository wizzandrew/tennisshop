<template>
  <div class="headerHolder">
    <div class="container">
      <nav class="navbar mainlinksNav">
        <div class="container-fluid">
          <a class="navbar-brand mainlinksNavBrand" href="/"
            ><img src="../img/tennisshop-logo.svg" alt="brand"
          /></a>
          <div class="search">
            <form class="d-flex" role="search">
              <input
                class="form-control me-2"
                type="search"
                placeholder=""
                aria-label="Search"
              />
              <button class="btn btn-outline-secondary" type="submit">
                Search
              </button>
            </form>
          </div>
          <div class="userThings">
            <div class="userThing">
              <a href="/my-account">
                <img src="../img/account-icon.svg" alt="account" />
                <p>My Account</p>
              </a>
            </div>
            <div class="userThing">
              <a href="/cart">
                <img src="../img/cart-icon.svg" alt="cart" />
                <p>Cart</p>
              </a>
            </div>
          </div>
        </div>
      </nav>
    </div>

    <nav class="navbar sublinksNav navbar-expand-lg">
      <div class="container-fluid">
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav subHeader me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <a class="nav-link" href="/rackets">Tennis rackets</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/clothing">Tennis clothing</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/shoes">Tennis shoes</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/accessories">Tennis accessories</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>
</template>

<style lang="scss">
@import "../assets/_sass";

.mainlinksNav {
  padding-bottom: 20px;

  .mainlinksNavBrand {
    margin-left: 100px;
    margin-right: 100px;
  }

  .search {
    max-width: fit-content;

    form input {
      min-width: 350px;
    }
  }

  .userThings {
    margin-left: 50px;
    display: flex;

    .userThing {
      padding: 0 20px;

      a {
        @include displayFlex(column);
        text-decoration: none;
        color: black;
        font-size: 12px;

        img {
          width: 22.4px;
          height: 22.4px;
          margin: 0 auto;
        }

        p {
          margin-bottom: 0px;
        }

        &:last-child img {
          transform: rotateY(180deg);
        }
      }
    }
  }
}

.container-fluid {
  justify-content: flex-start !important;
}

.sublinksNav {
  border-top: 2px solid #eee;
  border-bottom: 2px solid #eee;
  max-height: 40px;

  #navbarSupportedContent {
    display: flex;
    justify-content: center;
  }

  .subHeader {
    margin-right: 0 !important;

    li {
      @include underlineEffect();
      font-weight: 600;
      padding: 0 10px;

      &:hover {
        @include underlineEffectHover();
      }
    }
  }
}
</style>
