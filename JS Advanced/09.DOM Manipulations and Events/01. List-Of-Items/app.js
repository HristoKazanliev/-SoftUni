function addItem() {
    let userInput = document.getElementById('newItemText').value;
    let liElement = document.createElement('li');
    liElement.textContent = userInput;

    document.getElementById('items').appendChild(liElement);
    document.getElementById('newItemText').value = '';
}