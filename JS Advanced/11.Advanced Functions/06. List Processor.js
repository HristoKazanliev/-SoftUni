function solve(input) {
    let result = inner();

    for (let data of input) {
        let [cmd, value] = data.split(' ');

        if (cmd == 'add') {
            result.add(value);
        } else if (cmd == 'remove'){
            result.remove(value);
        } else {
            result.print();
        }
    } 

    function inner() {
        let text = [];

        return {
            add: (str) => text.push(str),
            remove: (str) => text = text.filter(x => x !== str),
            print: () => console.log(text.join(','))
        };
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);

