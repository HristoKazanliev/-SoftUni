class List {
    #list = [];
    constructor() {
        this.size =  this.#list.length;
    }

    add(value) {
        this.#list.push(value);
        this.#list.sort((a, b) => a - b);
        this.size++;
    }

    remove(value) {
        if (value < 0 || value >= this.size) {
            throw new Error;
        }
        this.size--;
        this.#list.splice(value, 1);
    }

    get(value) {
        if (value < 0 || value >= this.size) {
            throw new Error;
        }
        return this.#list[value];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1); 
console.log(list.get(1));