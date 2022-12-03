import page from "../../node_modules/page/page.mjs";
import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { onDetails, onUpdate } from "../api.js";

function editTemplate(album) {
    return html`
    <section id="edit">
        <div class="form">
          <h2>Edit Album</h2>
          <form class="edit-form" @submit=${onSubmit}>
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" value="${album.singer}"/>
            <input type="text" name="album" id="album-album" placeholder="Album" value="${album.album}"/>
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" value="${album.imageUrl}"/>
            <input type="text" name="release" id="album-release" placeholder="Release date" value="${album.release}"/>
            <input type="text" name="label" id="album-label" placeholder="Label" value="${album.label}"/>
            <input type="text" name="sales" id="album-sales" placeholder="Sales" value="${album.sales}"/>

            <button type="submit" id=${album._id}>post</button>
          </form>
        </div>
      </section>`;
}

export async function editView(ctx) {
    let album = await onDetails(ctx.params.detailsId);
    render(editTemplate(album), document.querySelector('main'));
}

async function onSubmit(event) {
    event.preventDefault();

    let data = Object.fromEntries(new FormData(event.target));
    let values = Object.values(data);

    if (values.includes('')) return alert('All fields are required')
    
    let id = event.currentTarget.querySelector('button').id;
    await onUpdate(data, id);
    page.redirect('/dashboard');
}