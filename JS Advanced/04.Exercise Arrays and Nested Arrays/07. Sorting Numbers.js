function solve(array) {
    let sortedArray = array.sort((a, b) => a - b);
    let newArray = [];

    while (sortedArray.length != 0) {
        newArray.push(sortedArray.shift(), sortedArray.pop()); 
    }
    return newArray;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));