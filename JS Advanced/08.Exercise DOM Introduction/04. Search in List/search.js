function search() {
   let searchedText = document.getElementById('searchText').value;
   let townsArray = document.querySelectorAll('#towns li');
   let result = document.getElementById('result');
   let count = 0;

   for (const town of townsArray) {
      if (town.textContent.includes(searchedText)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         count++;
      } else {
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none';
      }
   }

   result.textContent = `${count} matches found`;
}
