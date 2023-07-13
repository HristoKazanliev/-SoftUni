function solve() {
  let sections = document.querySelectorAll('section');
  let resultElement = document.querySelector("#results li h1");
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let correctCounter = 0;
  let index = 0;
debugger;
  Array.from(document.querySelectorAll('.quiz-answer'))
       .map(x => x.addEventListener('click', (answer) => {
        if (correctAnswers.includes(answer.target.innerHTML)) {
          correctCounter++;
        };
        sections[index].style.display = 'none';
        index++;

        index !== 3 ? sections[index].style.display = 'block' : printResult(correctCounter);
       }));
  
  function printResult(correctCounter) {
    resultElement.parentElement.parentElement.style.display = 'block';
    let result = '';

    correctCounter !== 3 
                   ? result = `You have ${correctCounter} right answers` 
                   : result = 'You are recognized as top JavaScript fan!';

    resultElement.textContent = result;
  }     

}
