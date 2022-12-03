import page from "../../node_modules/page/page.mjs";
import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { onLogin } from "../api.js";
import { updateNav } from "../app.js";

function loginTemplate() {
    return html`
    <!-- Login Page (Only for Guest users) -->
    <section id="login">
        <div class="form">
          <h2>Login</h2>
          <form class="login-form" @submit = ${onSubmit}>
            <input type="text" name="email" id="email" placeholder="email" />
            <input type="password" name="password" id="password" placeholder="password" />
            <button type="submit">login</button>
            <p class="message">
              Not registered? <a href="/register">Create an account</a>
            </p>
          </form>
        </div>
      </section>`;
}

export function loginView(ctx) {
    render(loginTemplate(), document.querySelector('main'));
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');

    if (email == '' || password == '') {
        return alert('All fields are required');
    }

    const result = await onLogin({ email, password });
    sessionStorage.setItem('token', result.accessToken);
    sessionStorage.setItem('ownerId', result._id);
    updateNav();
    page.redirect('/dashboard');
}
