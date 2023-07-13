function solve() {
  let [generateButton, buyButton] = document.querySelectorAll('button');
  let [inputElement, outputElement] = document.getElementsByTagName('textarea');
  generateButton.addEventListener('click', generate);
  buyButton.addEventListener('click', buy);

  function generate() {
    let currentItems = JSON.parse(inputElement.value);
    let tableBody = document.querySelector('tbody');

    for (let item of currentItems) {
      let tableRow = document.createElement('tr');
      tableRow.innerHTML = `<td><img src=${item.img}></td>` + 
                           `<td><p>${item.name}</p></td>` +
                            `<td><p>${item.price}</p></td>` +
                            `<td><p>${item.decFactor}</p></td>` +
                            `<td><input type="checkbox"/></td>`;

      tableBody.appendChild(tableRow);                      
    }
  }
  
  function buy() {
    let checkboxes = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'))
                     .map(p => p.parentElement.parentElement);

    let names = [];
    let totalPrice = 0;
    let totalDecFactor = 0; 
    
    for (let item of checkboxes) {
       let name = item.children[1].textContent.trim();
       let price = Number(item.children[2].textContent);
       let decFactor = Number(item.children[3].textContent);

       names.push(name);
       totalPrice += price;
       totalDecFactor += decFactor;
    }

    let avgdecFactor = totalDecFactor / names.length;
    let result = `Bought furniture: ${names.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgdecFactor}`;

    outputElement.value = result;
  }
}