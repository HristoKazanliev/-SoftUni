function solve(input) {
    let result = {};

    for (const pair of input) {
        let [name, population] = pair.split(" <-> ");
        if (!result[name]) {
            result[name] = 0;
        }

        result[name] += Number(population);
    }

    for (let town in result) {
       console.log(`${town} : ${result[town]}`);
    }
}

solve(
    ['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);

solve(
    ['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);