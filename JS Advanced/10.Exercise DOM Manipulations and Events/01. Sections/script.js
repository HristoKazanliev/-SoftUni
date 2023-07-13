function create(words) {
   let contentElement = document.getElementById('content');

   words.forEach(element => {
      let divElement = document.createElement('div');
      divElement.addEventListener('click', showText);

      let paragraphElement = document.createElement('p');
      paragraphElement.textContent = element;
      paragraphElement.style.display = 'none';

      divElement.appendChild(paragraphElement);
      contentElement.appendChild(divElement);
   });

   function showText(e) {
      e.currentTarget.firstChild.style.display = 'block';
   }
}