const { expect } = require('chai');
const { sum } = require('../04. Sum of Numbers');

describe('Sum tests', () => {
    it('Sould return correct sum', () => {
        expect(sum([1, 2, 3])).to.equal(6)
    })
    it('Should work with floating point numbers', () => {
        expect(sum([1.6, 1.5])).to.equal(3.1)
    })
    it('Should work with negative numbers', () => {
        expect(sum([-1, -1])).to.equal(-2)
    })
    it('Should work with epmty array  ', () => {
        expect(sum([])).to.equal(0)
    })
})