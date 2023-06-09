<template>
  <div class="about">
    <h1>About</h1>
    <button @click="store.increment()">{{ store.count }}</button>
  </div>
</template>

<script setup>
import { useCounterStore } from "../stores/counter";

// pinia
const store = useCounterStore();
</script>

<style>
button {
  font-size: 50px;
}
</style>
