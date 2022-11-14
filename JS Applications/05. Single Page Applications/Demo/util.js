export function sum(a, b) {
    verifyNum(a)
    verifyNum(b)
    return a + b;
}

export function product(a, b) {
    verifyNum(a)
    verifyNum(b)
    return a * b;
}

function verifyNum(input) {
    if (typeof input != 'number') {
        throw new TypeError('Argument must be a number');
    }
}

function printData() {
    console.log(data);
}

const data = [10, 20, 30];

export {
    data,
    printData
};

