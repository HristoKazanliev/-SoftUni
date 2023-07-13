function solve(array) {
    let dictionary = {};

    for (let i = 0; i < array.length; i+=2) {
        let product = array[i];
        let calories = Number(array[i+1])

        dictionary[product] = calories;
    }

    console.log(dictionary);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);