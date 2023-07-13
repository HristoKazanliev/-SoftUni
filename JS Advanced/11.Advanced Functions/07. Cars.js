function solve(input) {
    let data = [];
    let myFunc = properties();

    for (let line of input) {
        let[cmd, name, key, value] = line.split(' ');

        if (key == 'inherit') {
            cmd += key;
            key = value;
        }

        myFunc[cmd](name, key, value);
    }

    function properties() {
        let result = {
            create: (name) => data[name] = {},
            createinherit: (name, nameOfParent) => {
                let newObj = Object.create(data[nameOfParent]);
                data[name] = newObj;
            },
            set: (name, key, value) => {
                data[name][key] = value;
            },
            print: (name) => {
                let output = [];
                for (let pair in data[name]) {
                    output.push(`${pair}:${data[name][pair]}`);
                }

                console.log(output.join(','));
            }
        };

        return result;
    }
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
]);