let { expect } = require('chai');
let { mathEnforcer } = require('../04. Math Enforcer'); 

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('Should return undefined if type is not a number', () => {
            expect(mathEnforcer.addFive('test')).to.equal(undefined);
            expect(mathEnforcer.addFive({})).to.equal(undefined);
            expect(mathEnforcer.addFive([1])).to.equal(undefined);
        });
        it('Should work with float number', () => {
            expect(mathEnforcer.addFive(5.55)).to.be.closeTo(10.55, 0.01);
        });
        it('Should work with negative number', () => {
            expect(mathEnforcer.addFive(-10)).to.equal(-5);
        });
        it('Should work with positive number', () => {
            expect(mathEnforcer.addFive(10)).to.equal(15);
        });
    });

    describe('subtractTen', () => {
        it('Should return undefined if type is not a number', () => {
            expect(mathEnforcer.subtractTen('test')).to.equal(undefined);
            expect(mathEnforcer.subtractTen({})).to.equal(undefined);
            expect(mathEnforcer.subtractTen([1])).to.equal(undefined);
        });
        it('Should work with float number', () => {
            expect(mathEnforcer.subtractTen(10.5)).to.be.closeTo(0.5, 0.01);
        });
        it('Should work with negative number', () => {
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        });
        it('Should work with positive number', () => {
            expect(mathEnforcer.subtractTen(10)).to.equal(0);
        });
    });

    describe('sum', () => {
        it('Should return undefined if type is not a number', () => {
            expect(mathEnforcer.sum('test', 5)).to.equal(undefined);
            expect(mathEnforcer.sum(5,{})).to.equal(undefined);
            expect(mathEnforcer.sum('',[1])).to.equal(undefined);
        });
        it('Should work with float number', () => {
            expect(mathEnforcer.sum(10.55, 15.85)).to.be.closeTo(26.40, 0.01);
        });
        it('Should work with negative number', () => {
            expect(mathEnforcer.sum(-10, -20)).to.equal(-30);
        });
        it('Should work with positive number', () => {
            expect(mathEnforcer.sum(10, 20)).to.equal(30);
        });
    });
});