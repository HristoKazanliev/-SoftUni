const { expect } = require('chai');
const { rgbToHexColor } = require('../06. RGB to Hex');

describe('Valid input', () => {
    it('works correctly with integers for black', () => {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
    });
    it('works correctly with integers for white', () => {
        expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
    });
    //Invalid input
    it('return undefined with missing arguments', () => {
        expect(rgbToHexColor(0, 0)).to.be.undefined;
        expect(rgbToHexColor(0)).to.be.undefined;
        expect(rgbToHexColor()).to.be.undefined;
    });
    it('return undefined when not in the expected lower range', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.be.undefined;
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
    });
    it('return undefined when not in the expected upper range', () => {
        expect(rgbToHexColor(256, 0, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 256, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 0, 256)).to.be.undefined;
    });
    it('return undefined with floating point', () => {
        expect(rgbToHexColor(25.5, 0, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 25.5, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 0, 25.5)).to.be.undefined;
    });
    it('return undefined with string', () => {
        expect(rgbToHexColor('25.5', 0, 0)).to.be.undefined;
        expect(rgbToHexColor(0, '25.5', 0)).to.be.undefined;
        expect(rgbToHexColor(0, 0, '25.5')).to.be.undefined;
    });
});
