function solve(array) {
    let newArray = [];
    let biggestNumber = array[0];

    // for (const el of array) {
    //     if (el >= biggestNumber) {
    //         newArray.push(el);
    //         biggestNumber = el;
    //     }
    // }

    return newArray;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));