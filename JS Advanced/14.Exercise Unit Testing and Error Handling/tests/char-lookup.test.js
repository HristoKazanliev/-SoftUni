let { expect } = require('chai');
let { lookupChar } = require('../03. Char Lookup');

describe('Test with incorrect input', () => {
    it('Should return undefined with number for string', () => {
        expect(lookupChar(5, 5)).to.equal(undefined);
    });
    it('Should return undefined with object for string', () => {
        expect(lookupChar({}, 5)).to.equal(undefined);
    });
    it('Should return undefined with string for index', () => {
        expect(lookupChar('test', '2')).to.equal(undefined);
    });
    it('Should return undefined with float for index', () => {
        expect(lookupChar('test', 2.5)).to.equal(undefined);
    });
});

describe('Should return incorrect index', () => {
    it('With negative index', () => {
        expect(lookupChar('test', -1)).to.equal('Incorrect index');
    });
    it('When outside of the bounds', () => {
        expect(lookupChar('test', 6)).to.equal('Incorrect index');
    });
});

describe('Should work correctly', () => {
    it('With valid input', () => {
        expect(lookupChar('test', 2)).to.equal('s');
    });
});