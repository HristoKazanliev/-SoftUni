import { render } from "./template.js";

const username = 'John';
const items = [
    'Product 1',
    'Product 2',
    'Product 3'
];
    
const ctx = {
    username,
    items
};

const views = {
    'home-link': 'home',
    'catalog-link': 'catalog',
    'about-link': 'about'
}


document.querySelector('nav').addEventListener('click', (event) => {
    if (event.target.tagName == 'A') {
        const view = views[event.target.id];
        if (view !== undefined) {
            render(view, ctx);
        }
    }
});



