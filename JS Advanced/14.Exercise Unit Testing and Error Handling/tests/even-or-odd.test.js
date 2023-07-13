let { expect } = require('chai');
let { isOddOrEven } = require('../02. Even Or Odd');

describe('Should return undefined with input other than string', () => {
    it('Test with a number', () => {
        expect(isOddOrEven(5)).to.be.undefined;
    });
    it('Test with an object', () => {
        expect(isOddOrEven({number: 5})).to.be.undefined;
    });
});

describe('Should work correctly', () => {
    it('Test with even length', () => {
        expect(isOddOrEven('even')).to.equal('even');
    });
    it('Test with odd length', () => {
        expect(isOddOrEven('odd')).to.equal('odd');
    });
    it('Test with multiple strings', () => {
        expect(isOddOrEven('multiple different strings')).to.equal('even');
    });
});