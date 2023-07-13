function solve(input) {
    let result = [];
    let numbers = [];
    let operators = [];
    let operatorEnum = {
        "+": (a, b) => a + b,
        "-": (a, b) => a - b,
        "*": (a, b) => a * b,
        "/": (a, b) => a / b,
    };

    for (const el of input) {
        if (typeof (el) === "number") {
            numbers.push(el);
        } else {
            operators.push(el);
        }
    }

    if (operators.length < numbers.length - 1) {
        return console.log("Error: too many operands!");
    } else if (numbers.length === operators.length || numbers.length === 0) {
        return console.log("Error: not enough operands!");
    }

    for (const el of input) {
        if (typeof(el) === "number") {
            result.push(el);
            continue;
        }

        let numA = result.pop();
        let numB = result.pop();
        let operation = operatorEnum[el](numB, numA);
        result.push(operation);
    }
    
    console.log(result.join());
}

solve(
    [3,
    4,
    '+']);

solve(
    [5,
    3,
    4,
    '*',
    '-']);    