function calc() {
    let elementOne = document.getElementById('num1').value;
    let elementTwo = document.getElementById('num2').value;

    let result = document.getElementById('sum');
    result.value = Number(elementOne) + Number(elementTwo);
}
