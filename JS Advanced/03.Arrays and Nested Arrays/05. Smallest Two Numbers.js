function solve(numbers) {
    let result = numbers
        .sort((a, b) => a - b)
        //.sort((a, b) => b - a)
        .slice(0, 2);

    console.log(result.join(" "));
}

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);