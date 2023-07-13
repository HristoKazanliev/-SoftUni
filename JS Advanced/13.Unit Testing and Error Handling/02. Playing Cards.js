function solve(face, suit) {
    const facesEnum = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const suitsEnum = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663',
    };

    if (!facesEnum.includes(face) || suitsEnum[suit] == undefined) {
        throw new Error();
    }

    let result = {
        face, 
        suit: suitsEnum[suit],
        toString() {
            return this.face + this.suit;
        }
    };

    return result
}

console.log(solve('A', 'S').toString());
console.log(solve('10', 'H').toString());
console.log(solve('1', 'C').toString());