let chooseYourCar = require('./chooseYourCar');
let { expect, assert } = require('chai');

describe('Test chooseYourCar', () => {
    describe('Test method choosingType(type, color, year)', () => {
        it('Invalid Year', () => {
            expect(() => chooseYourCar.choosingType('string', 'color', 1899)).to.throw(Error, 'Invalid Year!');
            expect(() => chooseYourCar.choosingType('string', 'color', 2023)).to.throw(Error, 'Invalid Year!');
        })
        it('Invalid Type', () => {
            expect(() => chooseYourCar.choosingType('string', 'color', 2000)).to.throw(Error, 'This type of car is not what you are looking for.');
        })
        it('Invalid too old', () => {
            expect(chooseYourCar.choosingType('Sedan', 'red', 2000)).to.be.equal('This Sedan is too old for you, especially with that red color.');
        })
        it('Work correctly', () => {
            expect(chooseYourCar.choosingType('Sedan', 'red', 2010)).to.be.equal('This red Sedan meets the requirements, that you have.');
            expect(chooseYourCar.choosingType('Sedan', 'red', 2020)).to.be.equal('This red Sedan meets the requirements, that you have.');
        })
    });

    describe('Test method brandName(brands, brandIndex)', () => {
        let shop = ["Volkswagen", "BMW", "Audi"];

        it('Test Invalid Information One!', () => {
            expect(() => chooseYourCar.brandName("brands", 1)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(123, 1)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(undefined, 1)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(null, 1)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName({}, 1)).to.throw(Error, 'Invalid Information!');
        })
        it('Test Invalid Information Two!', () => {
            expect(() => chooseYourCar.brandName([], "brands")).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName([], undefined)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName([], null)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName([], {})).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName([], [])).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName([], -2)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(["Toyota", "Peugeot"], 3)).to.throw(Error, 'Invalid Information!');
        })
        it('should return correct message if matching models', () => {
            expect(chooseYourCar.brandName(shop, 2)).to.be.equal('Volkswagen, BMW')
        });
    });

    describe('Test method carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)', () => {
        it('Test Invalid distanceInKilometers', () => {
            expect(() => chooseYourCar.carFuelConsumption("brands", 5)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(undefined, 5)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(null, 5)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption({}, 5)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption([], 5)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(-10, 5)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(0, 5)).to.throw(Error, 'Invalid Information!');
        })
        it('Test Invalid consumptedFuelInLiters', () => {
            expect(() => chooseYourCar.carFuelConsumption(10, "brands")).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(10, undefined)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(10, null)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(10, {})).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(10, [])).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(10, -2)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(10, 0)).to.throw(Error, 'Invalid Information!');
        })
        it('Test carFuelConsumption over 7', () => {
            expect(chooseYourCar.carFuelConsumption(50, 10)).to.equal('The car burns too much fuel - 20.00 liters!')
        })
        it('Test carFuelConsumption under 7', () => {
            expect(chooseYourCar.carFuelConsumption(100, 5)).to.equal('The car is efficient enough, it burns 5.00 liters/100 km.')
            expect(chooseYourCar.carFuelConsumption(100, 7)).to.equal('The car is efficient enough, it burns 7.00 liters/100 km.')
        })
    });
});
