function solve(input) {
    let number = 1;
    let array = [];

    for (const cmd of input) {
        if (cmd == "add") {
            array.push(number);
        } else {
            array.pop();
        }

        number++;
    }

    return array.length == 0 ? "Empty" : array.join('\n');
}

console.log(solve(
    ['add',
    'add',
    'add',
    'add']));

console.log(solve(
    ['add',
    'add',
    'remove',
    'add',
    'add']));
    
console.log(solve(
    ['remove',
    'remove',
    'remove']));  