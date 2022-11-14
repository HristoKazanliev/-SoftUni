import { sum, product, data, printData } from "./util.js";

console.log(sum(5, 3));
console.log(product(5, 3));

console.log('Data before app.js');
console.log(data);

data.push(40);
printData();