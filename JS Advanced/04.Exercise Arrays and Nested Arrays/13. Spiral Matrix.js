function solve(rows, cols) {
    let matrix = [];
    for (let row = 0; row < rows; row++) {
        matrix.push([]);
    }

    let number = 1;
    let startRow = 0;
    let startCol = 0;
    let endRow = rows - 1;
    let endCol = cols - 1;
    let maxNum = rows * cols;
    
    while (number <= maxNum) {
        for (let col = startCol; col <= endCol; col++) {
            matrix[startRow][col] = number++;
        }
        startRow++;

        for (let row = startRow; row <= endRow; row++) {
            matrix[row][endCol] = number++;
        }
        endCol--;

        for (let col = endCol; col >= startCol; col--) {
            matrix[endRow][col] = number++;
        }
        endRow--;

        for (let row = endRow; row >= startRow; row--) {
            matrix[row][startCol] = number++;
        }
        startCol++;
    }

    matrix.forEach(row => console.log(row.join(" ")));
}

solve(5, 5);
solve(3, 3);
