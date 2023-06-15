import { ref, computed } from 'vue';
import { defineStore } from 'pinia'

export const shopStore = defineStore('sjop', () => {

    //state
    const newArrivals = ref();
    const topSellers = ref();

    //computed
    const newArrivalItems = computed(() => {
        return shopItemsToArray(newArrivals.value);
    });
    const topSellersItems = computed(() => {
        return shopItemsToArray(topSellers.value);
    });

    //methods
    function setNewArrivals(arrivals) {
        newArrivals.value = arrivals;
    }

    function setTopSellers(sellers) {
        topSellers.value = sellers;
    }

    //private functions
    //build an array of everything: accessories + clothings + shoes + rackets
    function shopItemsToArray(shopItems) {
        const items = [];

        if (shopItems !== undefined) {
            if (shopItems.accessories !== undefined && Array.isArray(shopItems.accessories)) {
                shopItems.accessories.map(acc => {
                    items.push(acc);
                })
            }

            if (shopItems.clothings !== undefined && Array.isArray(shopItems.clothings)) {
                shopItems.clothings.map(cloth => {
                    items.push(cloth);
                })
            }

            if (shopItems.shoes !== undefined && Array.isArray(shopItems.shoes)) {
                shopItems.shoes.map(shoe => {
                    items.push(shoe);
                })
            }

            if (shopItems.rackets !== undefined && Array.isArray(shopItems.rackets)) {
                shopItems.rackets.map(racket => {
                    items.push(racket);
                })
            }
        }

        return items;

    }

    return { newArrivals, topSellers, newArrivalItems, topSellersItems, setNewArrivals, setTopSellers }
})
