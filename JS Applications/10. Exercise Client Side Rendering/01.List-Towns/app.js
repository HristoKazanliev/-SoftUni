import { html, render } from './node_modules/lit-html/lit-html.js'

const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);
const root = document.querySelector('#root');

function onSubmit(event) {
    event.preventDefault();
    debugger
    let towns = [...new FormData(form).values()][0].split(', ');
    //console.log(towns);

    render(createTemplate(towns), root);
}

function createTemplate (towns) {
    const listTemplate = html`
    <ul>
    ${towns.map(t => html`<li>${t}</li>`)}
    </ul>`;

    return listTemplate;
}
