let { expect, assert } = require('chai');
let { PaymentPackage } = require('./12. Payment Package');

describe('Test constructor', () => {
    it('Should work with two parameters', () => {
        let package  = new PaymentPackage('Test', 10);
        assert(package instanceof PaymentPackage);
        assert.equal(package.name, 'Test');
        assert.equal(package.value, 10);
        assert.equal(package.VAT, 20);
        assert.equal(package.active, true);
    });
});

describe('Test name', () => {
    it('Should work throw an error with empty string', () => {
        assert.throws(() => new PaymentPackage('', 10), 'Name must be a non-empty string');
    });
    it('Should work throw an error with none string', () => {
        assert.throws(() => new PaymentPackage(10, 10), 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage([], 10), 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage({}, 10), 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage(undefined, 10), 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage(false, 10), 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage(), 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage(null, 10), 'Name must be a non-empty string');
    });
    it('should work correctly with valid data', () => {
        let packageTest = new PaymentPackage('Something', 50);
        packageTest.name = 'Something else';
        assert.equal(packageTest.name, 'Something else');
    });
});

describe('Test value', () => {
    it('Should work throw an error with negative number', () => {
        assert.throws(() => new PaymentPackage('Test', -1), 'Value must be a non-negative number');
    });
    it('Should work throw an error with not a number', () => {
        assert.throws(() => {new PaymentPackage('Test', '10')}, 'Value must be a non-negative number');
        assert.throws(() => {new PaymentPackage('Test', [])}, 'Value must be a non-negative number');
        assert.throws(() => {new PaymentPackage('Test', {})}, 'Value must be a non-negative number');
        assert.throws(() => {new PaymentPackage('Test', false)}, 'Value must be a non-negative number');
        assert.throws(() => {new PaymentPackage('Test', undefined)}, 'Value must be a non-negative number');
        assert.throws(() => {new PaymentPackage('Test')}, 'Value must be a non-negative number');
        assert.throws(() => {new PaymentPackage('Test', null)}, 'Value must be a non-negative number');
    });
    it('should work correctly with valid data', () => {
        let packageTest = new PaymentPackage('Something', 50);
        packageTest.value = 1000;
        assert.equal(packageTest.value, 1000);
        packageTest.value = 0;
        assert.equal(packageTest.value, 0);
    });
});

describe('Test VAT', () => {
    let package;
    beforeEach(() => package = new PaymentPackage('Test', 10));
    it('Should work throw an error with negative number', () => {
        assert.throws(() => {package.VAT = -1}, 'VAT must be a non-negative number');
    });
    it('Should work throw an error with not a number', () => {
        assert.throws(() => {package.VAT = []}, 'VAT must be a non-negative number');
        assert.throws(() => {package.VAT = {}}, 'VAT must be a non-negative number');
        assert.throws(() => {package.VAT = undefined}, 'VAT must be a non-negative number');
        assert.throws(() => {package.VAT = null}, 'VAT must be a non-negative number');
        assert.throws(() => {package.VAT = "10"}, 'VAT must be a non-negative number');
        assert.throws(() => {package.VAT = false}, 'VAT must be a non-negative number');
    });
    it('should work correctly with valid data', () => {
        package.VAT = 500;
        assert.equal(package.VAT, 500);
    });
    it('should have default value of 20', () => {
        assert.equal(20, package.VAT);
    });
});

describe('Test active', () => {
    let package;
    beforeEach(() => package = new PaymentPackage('Test', 10));
    it('Should work correctly', () => {
        package.active = false
        assert.equal(package.active, false);
    });
    it('Should work throw an error with not a bool', () => {
        assert.throws(() => {package.active = []}, 'Active status must be a boolean');
        assert.throws(() => {package.active = {}}, 'Active status must be a boolean');
        assert.throws(() => {package.active = undefined}, 'Active status must be a boolean');
        assert.throws(() => {package.active = null}, 'Active status must be a boolean');
        assert.throws(() => {package.active = "10"}, 'Active status must be a boolean');
        assert.throws(() => {package.active = 10}, 'Active status must be a boolean');
    });
    it('should have default value of true', () => {
        assert.equal(package.active, true);
    });
});

describe('Test toString', () => {
    let package;
    beforeEach(() => package = new PaymentPackage('Test', 10));
    it('Should work correctly', () => {
        let expected = 'Package: Test\n- Value (excl. VAT): 10\n- Value (VAT 20%): 12'
        let actual = package.toString();
        assert.equal(actual, expected);
    });
    it('Should work correctly with changed VAT', () => {
        package.VAT = 30;
        let expected = 'Package: Test\n- Value (excl. VAT): 10\n- Value (VAT 30%): 13'
        let actual = package.toString();
        assert.equal(actual, expected);
    });
    it('should return correct string if active status is false', ()=>{
        package.active = false;
        let expected = 'Package: Test (inactive)\n- Value (excl. VAT): 10\n- Value (VAT 20%): 12'
        let actual = package.toString();
        assert.equal(actual, expected);
    })
});