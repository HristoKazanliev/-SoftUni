function solve(string1, string2) {
    let num1 = Number(string1);
    let num2 = Number(string2);
    let sum = 0;

    for (let index = num1; index <= num2; index++) {
        sum += index;
    }

    return sum;
}

let result1 = solve('1', '5');
let result2 = solve('-8', '20');

console.log(result1);
console.log(result2);