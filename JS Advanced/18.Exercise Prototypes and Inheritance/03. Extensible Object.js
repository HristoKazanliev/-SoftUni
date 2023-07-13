function extensibleObject() {
    return {
        extend(input) {
            for (key in input) {
                if (typeof input[key] === 'function') {
                    Object.getPrototypeOf(this)[key] = input[key];
                } else {
                    this[key] = input[key];
                }
            }
        }
    }
}
    
const myObj = extensibleObject(); 
const template = { 
    extensionMethod: function () {}, 
    extensionProperty: 'someString' 
} 
myObj.extend(template); 