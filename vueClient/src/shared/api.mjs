import { URL } from "./utils";

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

export { getNewArrivals }