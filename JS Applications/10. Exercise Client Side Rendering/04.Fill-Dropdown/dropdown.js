import { html, render } from './node_modules/lit-html/lit-html.js';
import { get, post } from './api.js';

const root = document.getElementById('menu');

async function loadDropdown() {
    const data = await get();

    const template = html`
        ${data.map(option => html`<option value=${option._id}>${option.text}</option>`)}`;

    render(template, root);
}

loadDropdown();

document.querySelector('form').addEventListener('submit', addItem);
async function addItem(event) {
    event.preventDefault()

    const value = document.getElementById('itemText').value;
    value && await post({ text: value });

    loadDropdown();
}