import { ref, computed } from 'vue';
import { defineStore } from 'pinia';
import { useLocalStorage } from "@vueuse/core";

export const searchStore = defineStore('search', () => {

    //state
    const searchUpdated = useLocalStorage('searchupd', false);

    //methods

    function setSearchUpdate(update) {
        searchUpdated.value = update;
    }


    return {
        searchUpdated, setSearchUpdate
    }
})
