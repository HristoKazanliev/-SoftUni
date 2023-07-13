function solve(array, startIndex, endIndex) {
    if (!Array.isArray(array)) {
         return NaN;
    }
    let start = Math.max(startIndex, 0);
    let end = Math.min(endIndex, array.length - 1);
    let sum = 0;

    sum  = array.slice(start, end + 1)
    .map(x => Number(x))
    .reduce((acc, num) => acc + num, 0);
    // for (let i = start; i <= end; i++) {
    //     sum += Number(array[i]);
    // }

    return sum;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([], 1, 2));
console.log(solve('text', 0, 2));