<template>
  <div class="count">{{ store.count }}</div>
</template>

<script setup>
import { useCounterStore } from "../stores/counter";

// pinia
const store = useCounterStore();
</script>

<style>
.count {
  font-size: 60px;
  margin: 20px;
}
</style>
