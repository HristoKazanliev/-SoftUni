function solve(input) {
    let inputAsString = input.toString();
    let areTheSame = true;
    let sum = 0;
    let firstDigit = inputAsString[0];

    for (let index = 0; index < inputAsString.length; index++) {
        let digit = inputAsString[index];
        sum += Number(digit);

        if (firstDigit !== digit) {
            areTheSame = false;
        }
    }

    console.log(areTheSame);
    console.log(sum);
}

solve(2222222);
solve(1234);