function solve(input) {
    let juices = {};
    let bottles = new Map();

    for (let juiceInfo of input) {
        let [juice, value] = juiceInfo.split(' => ');
        let quantity = Number(value);
        if (!juices[juice]) {
            juices[juice] = 0;
        }   

        juices[juice] += quantity;
        let fullBottles = 0;
        let leftover = 0;

        if (juices[juice] >= 1000) {
            fullBottles = Math.floor(juices[juice] / 1000);
            leftover = juices[juice] % 1000;
            juices[juice] = leftover;

            if (!bottles[juice]) {
                bottles[juice] = 0;
            }

            bottles[juice] += fullBottles;
        }
    }

    return Object.entries(bottles).map(x => x.join(' => ')).join('\n');
}

console.log(solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']));