function extractText() {
    // const listOfElements = document.getElementById('items');
    // let textArea = document.getElementById('result');

    // textArea.value = listOfElements.textContent;
    const items = Array.from(document.querySelectorAll('li'));
    const result = items.map(e => e.textContent).join('\n');

    document.getElementById('result').value = result;
}