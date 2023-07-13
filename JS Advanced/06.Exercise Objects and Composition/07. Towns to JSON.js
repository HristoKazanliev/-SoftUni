function solve(input) {
    let result = [];
    const regex = new RegExp(/\s*\|\s*/);
    const columns = input[0].split(regex).filter(Boolean);

    for (let index = 1; index < input.length; index++) {
        let info = input[index].split(regex).filter(Boolean);

        let name = info[0];
        let latitude = Number(info[1]).toFixed(2);
        let longtitude = Number(info[2]).toFixed(2);

        let row = {};
        row[columns[0]] = name;
        row[columns[1]] = Number(latitude);
        row[columns[2]] = Number(longtitude);

        result.push(row);
    }

    return JSON.stringify(result);
}

console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));