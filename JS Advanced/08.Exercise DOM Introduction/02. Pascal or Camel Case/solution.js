function solve() {
  let input = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let result = '';

  let toCamelCase = (input) => {
    result = input
      .toLowerCase()
      .split(' ')
      .map((word, index) => index === 0 ? word : word[0].toUpperCase() + word.substring(1))
      .join('');
  }

  let toPascalCase = (input) => {
    result = input
      .toLowerCase()
      .split(' ')
      .map((word) => word[0].toUpperCase() + word.substring(1))
      .join('');
  }

  switch (namingConvention) {
    case "Camel Case": toCamelCase(input);
      break;
    case "Pascal Case": toPascalCase(input);
      break;
    default: result = 'Error!';
  }

  let resultElement = document.getElementById('result');
  resultElement.textContent = result;
}