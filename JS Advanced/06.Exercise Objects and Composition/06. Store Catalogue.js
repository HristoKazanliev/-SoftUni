function solve(input) {
    let result = {};

    for (const pair of input.sort((a, b) => a.localeCompare(b))) {
        let [product, price] = pair.split(" : ");
        price = Number(price);
        let firstLetter = product[0];
        let object = {product, price};

        if (!result[firstLetter]) {
            result[firstLetter] = [];
        }  
        
        result[firstLetter].push(object);
    }

    for (const letter of Object.keys(result)) {
        console.log(letter);
        for (const el of result[letter]) {
            console.log(`  ${el.product}: ${el.price}`);
        }
    }
}

solve(['Appricot : 20.4','Fridge : 1500', 'TV : 1499', 'Deodorant : 10', 'Boiler : 300', 'Apple : 1.25', 'Anti-Bug Spray : 15', 'T-Shirt : 10']);