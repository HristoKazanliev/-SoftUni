const { expect } = require('chai');
const { isSymmetric } = require('../05. Check for Symmetry');

describe('Symmetry Checker', () => {
    it('works correctly with symmetric array', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true
    });
    it('works incorrectly with non symmetric array', () => {
        expect(isSymmetric([1, 2, 2])).to.be.false
    });
    it('works incorrectly for non-array', () => {
        expect(isSymmetric(1)).to.be.false
    });
    it('works incorrectly with mismatched elements', () => {
        expect(isSymmetric([1, 2, '1'])).to.be.false
    })
    it('works correctly with symmetric string array ', () => {
        expect(isSymmetric(['a', 'b', 'b', 'a'])).to.be.true
    })
});