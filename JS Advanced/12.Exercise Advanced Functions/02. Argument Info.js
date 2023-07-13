function solve(...params) {
    let result = {};
    for (const item of params) {
        let type = typeof(item);
        console.log(`${type}: ${item}`);

        if (!result.hasOwnProperty(type)) {
            result[type] = 0;
        }
        result[type]++;
    }

    let sorted = Object.entries(result).sort((a, b) => b[1] - a[1]);
    for (let [key, value] of sorted) {
        console.log(`${key} = ${value}`);
    }
}

solve('cat', 42, function () { console.log('Hello world!'); });