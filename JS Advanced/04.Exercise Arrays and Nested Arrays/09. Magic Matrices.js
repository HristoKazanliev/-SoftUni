function solve(matrix) {
    let sum = matrix[0].reduce((sum, x) => sum + x);

   for (let row = 0; row < matrix.length; row++) {
        rowSum = 0;
        colSum = 0;
        for (let col = 0; col < matrix[row].length; col++) {
            if (col < matrix.length) {
                rowSum += matrix[row][col];
                colSum += matrix[col][row];
            }
        }

        if (rowSum != sum || colSum != sum) {
        return false;        
    }
   }

    return true;
}

console.log(solve(
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]))

console.log(solve(
    [[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]))    

console.log(solve(
    [[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]));    
// const matrix = [[4, 5, 6], [6, 5, 4], [5, 5, 5]]

// const rowSums = matrix.reduce((rowSums, currentRow) => {
//     rowSums.push(currentRow.reduce((sum, currentEl) => {
//         return sum + currentEl;
//     }))
//     return rowSums;
// }, []);

// console.log(rowSums)