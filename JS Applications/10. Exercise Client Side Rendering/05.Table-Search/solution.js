import { html, render } from './node_modules/lit-html/lit-html.js';
import { get } from './api.js';

async function solve() {
   const root = document.querySelector('tbody');
   const data = await get();
   const template = html`
   ${data.map(row => html`
   <tr>
      <td>${row.firstName} ${row.lastName}</td>
      <td>${row.email}</td>
      <td>${row.course}</td>
   </tr>`)}`;

   render(template, root);

   document.querySelector('#searchBtn').addEventListener('click', onClick);
   function onClick() {
      const searchedText = document.getElementById('searchField').value;
      const studentsInfo = root.querySelectorAll('tr');

      studentsInfo.forEach(studentRow => {
         const rowInfo = Array.from(studentRow.children).map(student => student.textContent).join(' ');
         
         searchedText && rowInfo.toLowerCase().includes(searchedText.toLowerCase()) 
         ? studentRow.classList.add('select')
         : studentRow.classList.remove('select');
      });

      document.getElementById('searchField').value = '';
   }
}

solve();