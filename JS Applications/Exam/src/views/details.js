import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { onDetails } from '../api.js';

function detailsTemplate(album) {
    return html`
        <section id="details">
        <div id="details-wrapper">
          <p id="details-title">Album Details</p>
          <div id="img-wrapper">
            <img src=".${album.imageUrl}" alt="example1" />
          </div>
          <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
            <p>
              <strong>Album name:</strong><span id="details-album">${album.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
          </div>
          <div id="likes">Likes: <span id="likes-count">0</span></div>
          <div>
                <div id="action-buttons">
                ${sessionStorage.ownerId !== undefined && sessionStorage.ownerId != album._ownerId
                ? actionButtonsCaseNonCreator(album)
                : null
                }

                ${sessionStorage.ownerId == album._ownerId
                ? actionButtonsCaseCreator(album)
                : null}
                </div>
            </div>
          <!--Edit and Delete are only for creator-->
          
        </div>
      </section>`;
}

function actionButtonsCaseNonCreator() {
    return html`<a href="#" id="like-btn">Like</a>`;
}

function actionButtonsCaseCreator(album) {
    return html`
    <a href="/edit/${album._id}" id="edit-btn">Edit</a>
    <a href="/delete/${album._id}" id="delete-btn">Delete</a>`;
}

export async function detailsView(ctx){
    let album = await onDetails(ctx.params.detailsId);
    render(detailsTemplate(album), document.querySelector('main'))
}
    
    
