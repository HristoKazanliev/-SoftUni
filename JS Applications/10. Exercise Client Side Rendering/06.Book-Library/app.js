import { html, render } from './node_modules/lit-html/lit-html.js';
import { initialTemplate } from "./src/initial.js";
import { get, post, put, del } from "./src/api.js";
const body = document.querySelector('body');

function onLoad() {
    render(initialTemplate, body)
}
onLoad();

const loadBooksBtn = document.getElementById('loadBooks');
loadBooksBtn.addEventListener('click', loadBooks);
const root = document.querySelector('tbody');

async function loadBooks() {
    let books = await get();

    const template = html`
        ${books.map(book => html`
        <tr .id=${book[0]}>
            <td>${book[1].title}</td>
            <td>${book[1].author}</td>
            <td>
                <button .id=${book[0]}>Edit</button>
                <button .id=${book[0]}>Delete</button>
            </td>
        </tr>`)}`;

    render(template, root);
    root.querySelectorAll('button:nth-of-type(1)').forEach(b => b.addEventListener('click', onEdit));
    root.querySelectorAll('button:nth-of-type(2)').forEach(b => b.addEventListener('click', onDelete));
}

const addForm = document.getElementById('add-form');
addForm.addEventListener('submit', onAdd);

async function onAdd(event) {
    event.preventDefault();

    const data = new FormData(addForm);
    let title = data.get('title');
    let author = data.get('author');

    if (title == '' || author == '') return;
    
    let response = await post({ title, author });

    if (response.status == 200) {
        loadBooks();
    }

    addForm.reset();
}

const editForm = document.getElementById('edit-form');
async function onEdit(e) {
    addForm.style.display = 'none';
    editForm.style.display = 'block';

    let title = e.target.parentElement.parentElement.children[0].textContent;
    let author = e.target.parentElement.parentElement.children[1].textContent;
    let [idInput, titleInput, authorInput] = editForm.querySelectorAll('input');

    idInput.value = e.target.id;
    titleInput.value = title;
    authorInput.value = author;
}

editForm.addEventListener('submit', onSave);
async function onSave(event) {
    event.preventDefault();

    let formData = new FormData(editForm);

    let id = formData.get('id');
    let title = formData.get('title');
    let author = formData.get('author');

    if (title == '' || author == '') return;

    let response = await put(id, { title, author });

    if (response.status == 200) {
        loadBooks();
    }

    editForm.reset();
    addForm.style.display = 'block';
    editForm.style.display = 'none';

}

async function onDelete(e) {
    console.log(e.target);
    del(e.target.id);
    e.target.parentElement.parentElement.remove();
}