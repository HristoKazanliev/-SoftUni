import { createIdea } from "../api/data.js";

let section = document.getElementById('createPage');
let form = section.querySelector('form');
form.addEventListener('submit', onSubmit)
let ctx = null;

export function showCreate(context){
    ctx = context;
    context.showSection(section);
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const title  = formData.get('title ');
    const description  = formData.get('description ');
    let img = formData.get('imageURL');

    await createIdea({title, description, img});
    form.reset();
    ctx.updateNav();
    ctx.goTo('/catalog');
}