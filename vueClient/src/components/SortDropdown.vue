<template>
  <div class="dropdown">
    <button
      class="btn btn-secondary dropdown-toggle"
      type="button"
      data-bs-toggle="dropdown"
      aria-expanded="false"
    >
      {{ selectedOption }}
    </button>
    <ul class="dropdown-menu">
      <li>
        <a class="dropdown-item" @click="sort(mostPopular)">{{
          mostPopular
        }}</a>
      </li>
      <li>
        <a class="dropdown-item" @click="sort(lowToHigh)">{{ lowToHigh }}</a>
      </li>
      <li>
        <a class="dropdown-item" @click="sort(highToLow)">{{ highToLow }}</a>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref } from "vue";
//const props = defineProps(["handleSorting"]);
const mostPopular = "Most popular";
const lowToHigh = "Price low-to-high";
const highToLow = "Price high-to-low";
const selectedOption = ref(mostPopular);
const emit = defineEmits("select");

const sort = (msg) => {
  selectedOption.value = msg;
  emit("select", msg);
};
</script>

<style>
.dropdown-menu {
  .dropdown-item {
    &:hover {
      cursor: pointer;
    }
  }
}
</style>
