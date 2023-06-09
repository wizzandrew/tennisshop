<template>
  <div class="home">
    <Counter />
    <div class="buttons">
      <button @click="store.decrement()">-</button>
      <button @click="store.increment()">+</button>
    </div>
    <hr />
    <div>This number is {{ store.oddOrEven }}</div>
  </div>
  <hr />
  <div>
    <h3>Edit counter</h3>
    <input type="number" v-model="store.count" />
  </div>
</template>

<script setup>
import Counter from "../components/Counter.vue";
import { useCounterStore } from "../stores/counter";

// pinia
const store = useCounterStore();
</script>

<style>
.buttons button {
  font-size: 40px;
  margin: 10px;
}
</style>
