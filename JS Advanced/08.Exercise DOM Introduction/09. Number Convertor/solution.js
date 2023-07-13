function solve() {
    document.querySelector('#container button').addEventListener('click', convert);
        let selectElement = document.getElementById('selectMenuTo');
        let optionBinary = document.createElement('option');
        optionBinary.textContent = 'Binary';
        optionBinary.value = 'binary';

        let optionHexadecimal = document.createElement('option');
        optionHexadecimal.textContent = 'Hexadecimal';
        optionHexadecimal.value = 'hexadecimal';

        selectElement.appendChild(optionBinary);
        selectElement.appendChild(optionHexadecimal);

        function convert() {
        let result = document.getElementById('result');
        let inputElement = Number(document.getElementById('input').value);
            
        if (selectElement.value == 'binary') {
            result.value = inputElement.toString(2); 
        } else {
            result.value = inputElement.toString(16).toUpperCase();
        }

    }
}