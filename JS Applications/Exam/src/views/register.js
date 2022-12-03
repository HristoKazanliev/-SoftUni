import page from '../../node_modules/page/page.mjs';
import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { onRegister } from '../api.js';
import { updateNav } from '../app.js';

function registerTemplate() {
    return html`
    <!-- Register Page (Only for Guest users) -->
    <section id="register">
        <div class="form">
          <h2>Register</h2>
          <form class="login-form" @submit=${onSubmit}>
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
          </form>
        </div>
      </section>`;
}

export function registerView(ctx) {
    render(registerTemplate(), document.querySelector('main'));
}

async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');
    const repeatPassword = formData.get('re-password');

    if (email == "" || password == "" || repeatPassword == "") {
        return alert("All fields required!");
    }
    if (password != repeatPassword) {
        return alert("Password doesn't match!");
    }

    const result = onRegister({ email, password });
    sessionStorage.setItem('token', result.accessToken);
    sessionStorage.setItem('ownerId', result._id);
    updateNav();
    page.redirect('/dashboard');

}