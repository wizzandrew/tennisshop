<template>
  <div v-if="searchOutput?.navigate">
    <div v-if="searchOutput?.navigate.page === 'racket'"><RacketsVue /></div>
    <div v-else-if="searchOutput?.navigate.page === 'cloth'">
      <ClothingVue />
    </div>
    <div v-else-if="searchOutput?.navigate.page === 'shoe'"><ShoesVue /></div>
    <div v-else-if="searchOutput?.navigate.page === 'accessor'">
      <AccessoriesVue />
    </div>
  </div>
</template>

<script setup>
import { useRoute } from "vue-router";
import { storeToRefs } from "pinia";
import { shopStore } from "../stores/shop";
import { searchStore } from "../stores/search-store";
import { search } from "../shared/search";
import { onMounted, onUpdated, ref } from "vue";
import RacketsVue from "./RacketsVue.vue";
import ClothingVue from "./ClothingVue.vue";
import ShoesVue from "./ShoesVue.vue";
import AccessoriesVue from "./AccessoriesVue.vue";

const _shopStore = shopStore();
const _searchStore = searchStore();

const { shopItems } = storeToRefs(_shopStore);
const { searchUpdated } = storeToRefs(_searchStore);

const route = useRoute();
const searchString = route.query.searchString;
const searchOutput = ref();

onMounted(() => {
  if (searchString !== "") {
    searchOutput.value = search(searchString, shopItems.value);
    _searchStore.setSearchUpdate(true);
    console.log("mounted: " + searchUpdated.value);
  }
  console.log("search optput: " + searchOutput);
});

onUpdated(() => {
  if (searchString !== "" && searchUpdated.value === false) {
    searchOutput.value = search(searchString, shopItems.value);
    _searchStore.setSearchUpdate(true);
    console.log("updated: " + searchUpdated.value);
  }

  console.log("search optput: " + searchOutput);
});
</script>
