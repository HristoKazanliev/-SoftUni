function solve(input) {
    let rows = input[0];
    let cols = input[1];
    let startRow = input[2];
    let startCol = input[3];

    let matrix = [];
    for (let row = 0; row < rows; row++) {
        matrix.push([]);
    }

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - startRow), Math.abs(col - startCol)) + 1;
        }
    }

    matrix.forEach(row => console.log(row.join(" ")));
}

solve([4, 4, 0, 0]);
solve([5, 5, 2, 2]);
solve([3, 3, 2, 2]);