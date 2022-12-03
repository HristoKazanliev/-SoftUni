import { html, render } from "../../node_modules/lit-html/lit-html.js";

function homeTemplate() {
    return html`<!-- Home page -->
      <section id="home">
        <img src="./images/landing.png" alt="home" />

        <h2 id="landing-text"><span>Add your favourite albums</span> <strong>||</strong> <span>Discover new ones right
            here!</span></h2>
      </section>`;
}

export async function homeView(){
    render(homeTemplate(), document.querySelector('main'))
}