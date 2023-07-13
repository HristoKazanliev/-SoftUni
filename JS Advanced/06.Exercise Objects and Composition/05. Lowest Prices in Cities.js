function solve(input) {
    let result = [];

    for (const element of input) {
        let [town, product, price] = element.split(" | ");
        price = Number(price);

        let object = result.find(x => x.product === product);
        if (object) {
            if (price < object.price) {
                object.price = price;
                object.town = town;
            }
        } else {
            object = {product, price, town};
            result.push(object);
        }
    }

    result.forEach(el => console.log(`${el.product} -> ${el.price} (${el.town})`));
}

solve(
    ['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);