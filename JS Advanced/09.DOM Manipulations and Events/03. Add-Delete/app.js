function addItem() {
    let inputElement = document.getElementById('newItemText').value;
    let liElement = document.createElement('li');
    liElement.textContent = inputElement;
    document.getElementById('items').appendChild(liElement);

    let aElement = document.createElement('a');
    aElement.href = '#';
    aElement.textContent = '[Delete]';
    liElement.appendChild(aElement);
    
    aElement.addEventListener('click', () => {
        aElement.parentElement.remove();    
    });
    inputElement.value = '';
}

