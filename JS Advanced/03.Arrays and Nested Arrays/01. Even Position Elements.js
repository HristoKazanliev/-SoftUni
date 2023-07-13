function solve(numbers) {
//    let evenIndexNums = [];

//    for (let i = 0; i < numbers.length; i++) {
//         if (i % 2 == 0) {
//             evenIndexNums.push(numbers[i]);
//         }
//    }

//    console.log(evenIndexNums.join(" "));

       return numbers
       .filter((num, index) => index % 2 == 0) 
       .join(" ");
}

console.log(solve([20, 30, 40, 50, 60]));

solve(['20', '30', '40', '50', '60']);
solve(['5', '10']);