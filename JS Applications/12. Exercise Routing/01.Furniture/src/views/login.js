import page from '../../node_modules/page/page.mjs';
import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { onLogin } from '../api.js';
import { updateNav } from '../app.js';


function loginTemplate() {
    return html`
    <div class="row space-top">
    <div class="col-md-12">
        <h1>Login User</h1>
        <p>Please fill all fields.</p>
    </div>
    </div>
    <form @submit = ${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <input type="submit" class="btn btn-primary" value="Login" />
        </div>
    </div>
    </form>`;
}

export function loginView(ctx) {
    render(loginTemplate(), document.querySelector('.container'));
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');

    const result = await onLogin({ email, password });
    sessionStorage.setItem('token', result.accessToken);
    sessionStorage.setItem('ownerId', result._id);
    updateNav();
    page.redirect('/catalog');
}
