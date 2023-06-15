import { ref, computed } from 'vue';
import { defineStore } from 'pinia'

export const shopStore = defineStore('sjop', () => {

    //state
    const newArrivals = ref();

    //computes
    const newArrivalItems = computed(() => {
        const items = [];

        if (newArrivals.value !== undefined) {
            if (newArrivals.value.accessories !== undefined && Array.isArray(newArrivals.value.accessories)) {
                newArrivals.value.accessories.map(acc => {
                    items.push(acc);
                })
            }

            if (newArrivals.value.clothings !== undefined && Array.isArray(newArrivals.value.clothings)) {
                newArrivals.value.clothings.map(cloth => {
                    items.push(cloth);
                })
            }

            if (newArrivals.value.shoes !== undefined && Array.isArray(newArrivals.value.shoes)) {
                newArrivals.value.shoes.map(shoe => {
                    items.push(shoe);
                })
            }

            if (newArrivals.value.rackets !== undefined && Array.isArray(newArrivals.value.rackets)) {
                newArrivals.value.rackets.map(racket => {
                    items.push(racket);
                })
            }
        }

        return items;
    });

    //methods
    function setNewArrivals(arrivals) {
        newArrivals.value = arrivals;
    }

    return { newArrivals, newArrivalItems, setNewArrivals }
})
