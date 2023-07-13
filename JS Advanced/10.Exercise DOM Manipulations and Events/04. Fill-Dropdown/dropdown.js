function addItem() {
    let newItemText = document.getElementById('newItemText');
    let newItemValue = document.getElementById('newItemValue');

    let newOption = document.createElement('option');
    newOption.textContent = newItemText.value;
    newOption.value = newItemValue.value;

    let addToMenu = document.getElementById('menu');
    addToMenu.appendChild(newOption);

    newItemText.value = '';
    newItemValue.value = '';
}