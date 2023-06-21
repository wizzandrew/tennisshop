import { ref, computed } from 'vue';
import { defineStore } from 'pinia';
import { useLocalStorage } from "@vueuse/core";


export const shopStore = defineStore('shop', () => {

    //state
    const shopItems = useLocalStorage('shopitems', []);
    const newArrivals = useLocalStorage('newarrivals', []);
    const topSellers = useLocalStorage('topsellers', []);

    //computed
    const accessoryItems = computed(() => {
        return shopItemsToAccessories(shopItems.value);
    });
    const clothingItems = computed(() => {
        return shopItemsToClothings(shopItems.value);
    });
    const shoeItems = computed(() => {
        return shopItemsToShoes(shopItems.value);
    });
    const racketItems = computed(() => {
        return shopItemsToRackets(shopItems.value);
    });
    const newArrivalItems = computed(() => {
        return shopItemsToArray(newArrivals.value);
    });
    const topSellersItems = computed(() => {
        return shopItemsToArray(topSellers.value);
    });

    //methods

    function setShopItems(shopitems) {
        shopItems.value = shopitems;
    }

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

            items.push(...shopItemsToAccessories(shopItems));

            items.push(...shopItemsToClothings(shopItems));

            items.push(...shopItemsToShoes(shopItems));

            items.push(...shopItemsToRackets(shopItems));
        }

        return items;

    }

    function shopItemsToAccessories(shopItems) {
        const items = [];

        if (shopItems !== undefined) {

            if (shopItems.accessories !== undefined && Array.isArray(shopItems.accessories)) {
                shopItems.accessories.map(acc => {
                    items.push(acc);
                })
            }
        }

        return items;

    }

    function shopItemsToClothings(shopItems) {
        const items = [];

        if (shopItems !== undefined) {

            if (shopItems.clothings !== undefined && Array.isArray(shopItems.clothings)) {
                shopItems.clothings.map(cloth => {
                    items.push(cloth);
                })
            }
        }

        return items;

    }

    function shopItemsToShoes(shopItems) {
        const items = [];

        if (shopItems !== undefined) {

            if (shopItems.shoes !== undefined && Array.isArray(shopItems.shoes)) {
                shopItems.shoes.map(shoe => {
                    items.push(shoe);
                })
            }
        }

        return items;

    }

    function shopItemsToRackets(shopItems) {
        const items = [];

        if (shopItems !== undefined) {

            if (shopItems.rackets !== undefined && Array.isArray(shopItems.rackets)) {
                shopItems.rackets.map(racket => {
                    items.push(racket);
                })
            }
        }

        return items;

    }

    return {
        newArrivals, topSellers, shopItems,
        accessoryItems, clothingItems, shoeItems, racketItems, newArrivalItems, topSellersItems,
        setShopItems, setNewArrivals, setTopSellers
    }
})
