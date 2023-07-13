function solve(matrix) {
    let primaryDiagonal = 0;
    let secondaryDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {
        primaryDiagonal += matrix[row][row];
        secondaryDiagonal += matrix[row][matrix.length - 1 - row];
    }

    console.log(`${primaryDiagonal} ${secondaryDiagonal}`);
}

solve([
    [20, 40],
    [10, 60]]);

solve([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]);   

