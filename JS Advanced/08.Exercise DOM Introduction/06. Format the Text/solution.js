function solve() {
  let textFromInput = document.getElementById('input').value; 
  let resultElement = document.getElementById('output');
  let textArray = textFromInput.split('.').filter(x => x.length > 0);
  resultElement.innerHTML = '';

  for (let i = 0; i < textArray.length; i+=3) {
    let result = [];
    for (let j = 0; j < 3; j++) {
      if (textArray[i + j]) {
        result.push(textArray[i + j]);
      }
    }
    let formattedText = result.join('. ') + '.';
    resultElement.innerHTML += `<p>${formattedText}</p>`;
  }
}