import { register } from "../api/users.js";

let section = document.getElementById('registerPage');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
let ctx = null;

export function showRegister(context){
    ctx = context;
    context.showSection(section);
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    await register(email, password);
    form.reset();
    ctx.updateNav();
    ctx.goTo('/');
}