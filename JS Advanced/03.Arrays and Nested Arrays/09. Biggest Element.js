function solve(matrix) {
    let biggestNumber = Number.MIN_SAFE_INTEGER;

    for (let row = 0; row < matrix.length; row++) {
        let currentNumber = Math.max(...matrix[row]);

        if (currentNumber > biggestNumber) {
            biggestNumber = currentNumber;
        }
    }

    return biggestNumber;
}

console.log(solve(
    [[20, 50, 10],
     [8, 33, 145]]));

console.log(solve(
    [[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]));