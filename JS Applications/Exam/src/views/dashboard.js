import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { getAllAlbums } from '../api.js';

function dashboardTemplate(catalog) {
    return html`
    <section id="dashboard">
        <h2>Albums</h2>
        <ul class="card-wrapper">
          <!-- Display a li with information about every post (if any)-->
          ${catalog.length > 0 
        ? catalog.map(album => albumCard(album))
        : html`<h2>There are no albums added yet.</h2>`}
        </ul>
    </section>`;
      
}

function albumCard(album) {
    return html`
        <li class="card">
            <img src=".${album.imageUrl}" alt="travis" />
            <p>
              <strong>Singer/Band: </strong><span class="singer">${album.singer}</span>
            </p>
            <p>
              <strong>Album name: </strong><span class="album">${album.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${album.sales}</span></p>
            <a class="details-btn" href="/details/${album._id}">Details</a>
        </li>`;
}

export async function catalogView(ctx) {
    let catalog = await getAllAlbums();
    render(dashboardTemplate(catalog), document.querySelector('main'));
}