<template>
  <div class="headerHolder">
    <div class="container">
      <nav class="navbar mainlinksNav">
        <div class="container-fluid">
          <a class="navbar-brand mainlinksNavBrand" href="/">Brand logo</a>
          <div class="search">
            <form class="d-flex" role="search">
              <input
                class="form-control me-2"
                type="search"
                placeholder="Search"
                aria-label="Search"
              />
              <button class="btn btn-outline-success" type="submit">
                Search
              </button>
            </form>
          </div>
          <div class="userThings">
            <div>
              <a href="/my-account">My Account</a>
            </div>
            <div>
              <a href="/cart">Cart</a>
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
              <a class="nav-link" href="/bags">Tennis bags</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/balls">Tennis balls</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/strings">Tennis strings</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>
</template>

<style>
.mainlinksNav {
  padding-bottom: 20px;
}

.mainlinksNavBrand {
  margin-left: 100px;
}

.container-fluid {
  justify-content: flex-start !important;
}

.search {
  margin-left: 100px;
  max-width: fit-content;
}

.search form input {
  min-width: 350px;
}

.userThings {
  margin-left: 50px;
  display: flex;
}

.userThings div {
  padding: 0 10px;
}

.userThings a {
  color: black;
}

.sublinksNav {
  border-top: 2px solid #eee;
  border-bottom: 2px solid #eee;
  max-height: 40px;
}

#navbarSupportedContent {
  display: flex;
  justify-content: center;
}

.subHeader {
  margin-right: 0 !important;
}

.subHeader li {
  font-weight: 600;
  padding: 0 10px;
}
</style>
