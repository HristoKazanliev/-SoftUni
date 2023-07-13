function solve(array) {
    let result = array
    .sort((a, b) => a.localeCompare(b))
    .forEach((element, number)=> console.log(`${++number}.${element}`));  
}

solve([
    "John",
    "Bob",
    "Christina",
    "Ema"]);