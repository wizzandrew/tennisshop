<template>
  <div class="app">
    <div>
      <Header />
    </div>

    <RouterView />
  </div>
</template>

<script setup>
import Header from "./components/Header.vue";
</script>
