import router from "../router/index";
import ShoesVue from "../views/ShoesVue.vue";

function search(searchInput, shopItems) {

    // variables
    const searchResult = {
        // specifies whether navigate to page(Rackets/Clothing/Shoes/Accessories) 
        // based on search input
        navigate: {
            page: ""
        },
        items: []
    };
    // specifies whether search achived results
    let searchFlag = false;
    // page search categories
    const categories = ["racket", "cloth", "shoe", "accessor"];

    // empty search
    if (searchInput.value === "") {
        alert("Empty search");
        return searchResult;
    }

    // make search string to lower case
    const searchString = searchInput.toLowerCase();

    // loop through shop items
    if (
        shopItems !== undefined &&
        Array.isArray(shopItems.accessories) &&
        shopItems.accessories.length > 0
    ) {
        // category search
        for (let i = 0; i < categories.length; i++) {
            if (searchString.includes(categories[i]) || searchString.split(" ").includes(categories[i])) {
                searchResult.navigate.page = categories[i];
                searchFlag = true;
                break;
            }
        }

        if (searchFlag) {
            return searchResult;
        }

        // shopItems.value.map((item) => {

        // })
    }
};

export { search }  