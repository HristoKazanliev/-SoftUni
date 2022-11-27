import { html, render } from './node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const root = document.getElementById('towns');
const result = document.getElementById('result');

const townsTemplate = html`
<ul>
   ${towns.map(town => html`<li>${town}</li>`)}
</ul>`;

render(townsTemplate, root);

document.querySelector('button').addEventListener('click', search);
function search() {
   const searchText = document.getElementById('searchText').value;
   const townList = root.querySelectorAll('li');
   let count = 0;

   townList.forEach(town => {
      if (town.textContent.includes(searchText)) {
         town.classList.add('active');
         count++;
      }else{
         town.classList.remove('active');
      }
   });

   result.textContent = `${count} matches found`;
}
