function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchedText = document.getElementById('searchField');
      let rowsArray = document.querySelectorAll('tbody tr');

      for (const row of rowsArray) {
         if (row.textContent.includes(searchedText.value)) {
            row.className = 'select';
         } else {
            row.classList.remove("select");
         }
      }

      searchedText.value = '';
   }
}