function solve(input) {
    let result = [];

    for (let number of input) {
            if (number < 0) {
                result.unshift(number);
            } else {
                result.push(number);
            }
    }

    result.forEach(x => {
        console.log(x);
    });
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);