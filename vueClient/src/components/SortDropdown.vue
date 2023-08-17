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
const props = defineProps(["emitName"]);
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
.dropdown {
  .dropdown-toggle {
    background-color: #f5f5f5;
    color: #424242;
    border: 0;
    font-size: 14px;
    border-radius: 0;

    &::after {
      margin-left: 47px;
    }
  }
  .dropdown-menu {
    .dropdown-item {
      font-size: 14px;
      &:hover {
        cursor: pointer;
      }
    }
    &.show {
      border-radius: 0;
    }
  }
}
</style>
