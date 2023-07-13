function solve(input) {
    // let firstNum = Number(input.shift());
    // let lastNum = Number(input.pop());

    // console.log(firstNum + lastNum);
    let numArray = input.map(x => Number(x));
    let sum = numArray[0] + numArray[numArray.length - 1];

    console.log(sum);
}

solve(['20', '30', '40']);
solve(['5', '10']);