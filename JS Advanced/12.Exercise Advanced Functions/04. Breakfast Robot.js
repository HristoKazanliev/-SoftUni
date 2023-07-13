function solution() {
    const ingredientsEnum = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    const recipesEnum = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    }

    let execute = {
        restock: (ingredient, quantity) => {
            ingredientsEnum[ingredient] += Number(quantity);
            return 'Success';
        },
        prepare: (recipe, quantity) => {
            let ingredientsNeeded = recipesEnum[recipe];
            let isEnough = true;

            for (let ingredient in ingredientsNeeded) {
                if (ingredientsEnum[ingredient] < ingredientsNeeded[ingredient] * quantity) {
                    isEnough = false;
                    return `Error: not enough ${ingredient} in stock`;
                }
            }

            if (isEnough) {
                for (let ingredient in ingredientsNeeded) {
                    ingredientsEnum[ingredient] -= ingredientsNeeded[ingredient] * quantity;
                }
                return 'Success';
            }
        },
        report: () => {
            let result = [];
            for (let ingredient in ingredientsEnum) {
                result.push(`${ingredient}=${ingredientsEnum[ingredient]}`);
            }
            return result.join(' ');
        }
    };

    return function cmdSplit(input) {
        let [cmd, ingredient, quantity] = input.split(' ');
        return execute[cmd](ingredient, quantity);
    }
}

let manager = solution ();
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log(manager("restock carbohydrate 10")); // Success 
console.log(manager("restock flavour 10")); // Success 
console.log(manager("prepare apple 1")); // Success
console.log(manager("restock fat 10")); // Success
console.log(manager("prepare burger 1")); // Success
console.log(manager("report")); // protein=0 carbohydrate=4 fat=3 flavour=55
