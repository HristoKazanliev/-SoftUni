function solve() {
    const url = 'http://localhost:3030/jsonstore/collections/books';
    const loadBtn = document.getElementById('loadBooks');
    const tbody = document.querySelector('tbody');
    const form = document.querySelector('form');
    let editId = '';
    form.addEventListener('submit', submitFunc);
    loadBtn.addEventListener('click', loadFunc);
    tbody.addEventListener('click', modifyFunc);

    async function submitFunc(e) {
        e.preventDefault();

        const data = new FormData(form);
        const bookObj = Object.fromEntries(data.entries());

        if (Object.values(bookObj).includes('')) {
            return
        }

        if (e.target[2].textContent == 'Save') {
            saveFunc(e);
            return;
        }

        await fetch(url, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(bookObj)
        });
        
       
        loadFunc();
    }

    async function loadFunc() {
        document.querySelector('[name="title"]').value = '';
        document.querySelector('[name="author"]').value = '';

        let response = await fetch(url);
        let data = Object.entries(await response.json());

        tbody.innerHTML = '';
        for (const [key, { author, title }] of data) {
            let row = document.createElement('tr');

            let btnCell = document.createElement('td');
            let editBtn = createTag('button', 'Edit', null, key);
            let deleteBtn = createTag('button', 'Delete', null, key);
            btnCell.appendChild(editBtn);
            btnCell.appendChild(deleteBtn);

            row.appendChild(createTag('td', title));
            row.appendChild(createTag('td', author));
            row.appendChild(btnCell);

            tbody.appendChild(row)
        }
    }

    function modifyFunc(e) {
        if (e.target.tagName !== 'BUTTON') {
            return
        } 
        e.target.textContent == 'Edit' ? editFunc(e.target) : deleteFunc(e);
    }

    async function saveFunc() {
        let { title, author } = Object.fromEntries(new FormData(form).entries());
        if (title == '' || author == '') return;
        document.querySelector('form h3').textContent = 'FORM';
        document.querySelector('form button').textContent = 'Submit';

        await fetch(`${url}/${editId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, author })
        });
        loadFunc()
    } 

    async function editFunc(e) {
        //let { title, author } = Object.fromEntries(new FormData(form).entries());
        //if (title == '' || author == '') return;
        editId = e.id;
        let oldTitle = e.parentElement.parentElement.children[0].textContent;
        let oldAuthor = e.parentElement.parentElement.children[1].textContent;

        document.querySelector('[name="title"]').value = oldTitle;
        document.querySelector('[name="author"]').value = oldAuthor;

        document.querySelector('form h3').textContent = 'Edit FORM';
        document.querySelector('form button').textContent = 'Save';
    }

    async function deleteFunc(e) {
        await fetch(`${url}/${e.target.id}`, {
            method: 'delete'
        });
        e.target.parentElement.parentElement.remove();
    };

    function createTag(tag, text = null, className = null, id = null, type = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (type) { el.type = type; }
        if (id) { el.id = id; }
        if (className) { el.className = className; }
        return el;
    }
}

async function getInfo() {
    let bookId = document.getElementById('bookId').value;
    const bookName = document.getElementById('bookName');
    const listOfBooks = document.getElementById('books');

    try {
        let result = await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`);

        listOfBooks.innerHTML = '';
        let data = await result.json();

        let row = document.createElement('li');
        row.textContent = `${data.author} wrote  ${data.title}.`;
        listOfBooks.appendChild(row);
       
    } catch (error) {
        bookName.textContent = 'Error';
        listOfBooks.innerHTML = '';
    }
}

solve();