<template>
  <div class="container">
    <h1>Home</h1>
  </div>
</template>

<script setup>
import Counter from "../components/Counter.vue";
import { useCounterStore } from "../stores/counter";

// pinia
const store = useCounterStore();
</script>

<style></style>
