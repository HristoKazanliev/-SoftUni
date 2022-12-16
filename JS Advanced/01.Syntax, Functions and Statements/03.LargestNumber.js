function solve(num1, num2, num3) {
    let maxNum;
    if (num1 > num2 && num1 > num3) {
        maxNum = num1;
    } else if (num2 > num1 && num2 > num3) {
        maxNum = num2;
    } else {
        maxNum = num3;     
    }
    
    console.log(`The largest number is ${maxNum}.`);
}

function secondSolution(...params) {
    console.log(`The largest number is ${Math.max(...params)}.`);
}

solve(5, -3, 16);
secondSolution(5, -3, 16);
