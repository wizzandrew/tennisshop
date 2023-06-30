import { URL } from "./utils";

async function getShopItems() {

    // variables for json response and result
    let response;
    let result;

    try {
        response = await fetch(URL + "Shopitem");
    } catch (error) {
        console.log("getShopItems " + error);
    }

    if (response !== undefined) {
        if (response.ok) {
            await response
                .json()
                .then((data) => (result = data))
                .catch((err) => console.log(err));

            // return json result
            return result;
        } else {
            throw new Error("\nStatus: " + response.status + " " + response.statusText);
        }
    }
    else {
        return null;
    }

}


async function getNewArrivals() {

    // variables for json response and result
    let response;
    let result;

    try {
        response = await fetch(URL + "Shopitem/newarrivals");
    } catch (error) {
        console.log("getNewArrivals " + error);
    }

    if (response !== undefined) {
        if (response.ok) {
            await response
                .json()
                .then((data) => (result = data))
                .catch((err) => console.log(err));

            // return json result
            return result;
        } else {
            throw new Error("\nStatus: " + response.status + " " + response.statusText);
        }
    }
    else {
        return null;
    }

}


async function getTopSellers() {

    // variables for json response and result
    let response;
    let result;

    try {
        response = await fetch(URL + "Shopitem/topsellers");
    } catch (error) {
        console.log("getTopSellers " + error);
    }

    if (response !== undefined) {
        if (response.ok) {
            await response
                .json()
                .then((data) => (result = data))
                .catch((err) => console.log(err));

            // return json result
            return result;
        } else {
            throw new Error("\nStatus: " + response.status + " " + response.statusText);
        }
    }
    else {
        return null;
    }

}

async function getUser() {

    // variables for json response and result
    let response;
    let result;

    try {
        response = await fetch(URL + "User");
    } catch (error) {
        console.log("getUser " + error);
    }

    if (response !== undefined) {
        if (response.ok) {
            await response
                .json()
                .then((data) => (result = data))
                .catch((err) => console.log(err));

            // return json result
            return result;
        } else {
            throw new Error("\nStatus: " + response.status + " " + response.statusText);
        }
    }
    else {
        return null;
    }

}

async function postCart(shoppingCart, orderTotal) {

    // variables for json response
    let response;

    // create request body
    const orderItems = [];
    shoppingCart?.map(s => {
        orderItems.push({
            id: 0,
            item: {
                id: s.item.id,
                name: "",
                brand: "",
                price: 0,
                salePrice: 0,
                quantity: 0,
                rating: 0,
                popular: false,
                description: "",
                img: ""
            },
            quantity: s.amount
        })
    });

    const requestBody = {
        orderNo: "Ord" + Math.floor(Math.random() * Date.now()).toString(16),
        date: new Date(),
        total: orderTotal,
        orderStatus: "Processing",
        items: orderItems
    }

    try {
        response = await fetch(URL + "Order/createorder", {
            method: "POST",
            body: JSON.stringify(requestBody),
            headers: {
                "Content-Type": "application/json",
            },
            credentials: "same-origin",
        });
    } catch (error) {
        console.log("postCart " + error);
    }

    if (response !== undefined) {
        if (response.ok) {

            alert(`Order No${requestBody.orderNo} placed.`);

            return true;

        } else {
            throw new Error("\nStatus: " + response.status + " " + response.statusText);
        }
    }
    else {
        return null;
    }

}


export { getShopItems, getNewArrivals, getTopSellers, getUser, postCart }