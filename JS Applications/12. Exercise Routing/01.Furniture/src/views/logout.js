import page from '../../node_modules/page/page.mjs';
import { onLogout } from "../api.js";
import { updateNav } from '../app.js';


export async function logout(event) {
    event.preventDefault();

    await onLogout();
    sessionStorage.clear();
    page.redirect('/catalog');
    updateNav();
}