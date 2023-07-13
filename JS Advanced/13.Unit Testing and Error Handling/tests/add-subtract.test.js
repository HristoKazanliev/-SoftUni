const { expect, assert } = require('chai');
const { createCalculator } = require('../07. Add-Subtract');

describe('Test correctly returned object', () => {
    it('Should return object', () => {
        assert.isObject(createCalculator());
    });
    it('Should return object with properties', () => {
        expect(createCalculator()).to.has.property('add');
        expect(createCalculator()).to.has.property('subtract');
        expect(createCalculator()).to.has.property('get');
    });
});

describe('Test add property', () => {
    it('Should return added result', () => {
        let calculator = createCalculator();
        calculator.add('5');
        calculator.add(5);
        expect(calculator.get()).to.be.equal(10)
    })
});

describe('Test subtract property', () => {
    it('Should return the difference', () => {
        let calculator = createCalculator();
        calculator.add(10);
        calculator.subtract('5');
        expect(calculator.get()).to.be.equal(5)
    })
});