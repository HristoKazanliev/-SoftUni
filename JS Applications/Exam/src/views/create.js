import { html, render } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { onCreate } from '../api.js';

function createTemplate() {
    return html`<!-- Create Page (Only for logged-in users) -->
      <section id="create">
        <div class="form">
          <h2>Add Album</h2>
          <form class="create-form" @submit=${onSubmit}>
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input type="text" name="release" id="album-release" placeholder="Release date" />
            <input type="text" name="label" id="album-label" placeholder="Label" />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
          </form>
        </div>
      </section>`;
}

export function createView() {
    render(createTemplate(), document.querySelector('main'));
}

async function onSubmit(event) {
    event.preventDefault();

    let data = Object.fromEntries(new FormData(event.target));
    let values = Object.values(data);

    if (values.includes('')) return alert('All fields are required')
    
    await onCreate(data);
    page.redirect('/dashboard');
}