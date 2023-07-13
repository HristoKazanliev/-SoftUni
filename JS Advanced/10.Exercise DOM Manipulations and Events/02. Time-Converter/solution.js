function attachEventsListeners() {
    let buttonElements = document.querySelectorAll('div input[type="button"]');
    let inputElements = document.querySelectorAll('div input[type="text"]');
    const table = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    };

    function displayConvert(e) {
        let inputText = e.target.parentElement.querySelector('input[type="text"]');
        let inputTextValue = inputText.value;
        let inputTextId = inputText.id;

        let convertedObject = convert(inputTextValue, inputTextId);

        for (let element of inputElements) {
            element.value = convertedObject[element.id];
        }
    }

    function convert(value, id) {
        let days = Number(value) / table[id];

        let converted = {
            days: days,
            hours: days * table.hours,
            minutes: days * table.minutes,
            seconds: days * table.seconds
        };

        return converted;
    }

    for (let button of buttonElements) {
        button.addEventListener('click', displayConvert);
    }
}