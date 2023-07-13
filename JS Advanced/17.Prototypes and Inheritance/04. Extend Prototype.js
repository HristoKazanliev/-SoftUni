function extendProrotype(classDef) {
    classDef.prototype.species = 'Human';
    classDef.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}

function Person(name, email) {
    this.name = name;
    this.email = email;
}

Person.prototype.toString = function () {
    return `To string method from prototype of ${this.name}`;
}

extendProrotype(Person);
let person = new Person('Gosho', 20);
console.log(person.toSpeciesString());
console.log(person.species);