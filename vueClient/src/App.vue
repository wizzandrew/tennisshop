<template>
  <div class="app">
    <div
      v-show="
        $route.path !== '/cart' &&
        $route.path !== '/cartUserInfo' &&
        $route.path !== '/cartCheckOrder'
      "
    >
      <Header />
    </div>

    <RouterView />

    <div>
      <Footer />
    </div>
  </div>
</template>

<script setup>
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";
</script>
