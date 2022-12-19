//Euclidean Algorithm for GCD

function gcd(a, b) {
    if (!b) {
        return a
    }
    return gcd(b, a % b);
}

let divisor = gcd(2154, 458);
console.log(divisor);