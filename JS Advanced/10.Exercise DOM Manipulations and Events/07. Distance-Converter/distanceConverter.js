function attachEventsListeners() {
    let buttonElement = document.getElementById('convert');
    let [inputElement, outputElement] = document.querySelectorAll('input[type="text"]');

    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');

    function convert() {
        let distanceToConvert = inputElement.value;
        let unitsFrom = inputUnits.value;
        let unitsTo = outputUnits.value;

        let distanceInMeters = distanceToConvert * table[unitsFrom];
        let result = distanceInMeters / table[unitsTo];
        outputElement.value = result;
    }

    buttonElement.addEventListener('click', convert);

    const table = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    };
}