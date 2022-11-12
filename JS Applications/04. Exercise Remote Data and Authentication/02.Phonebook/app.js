function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const phoneBook = document.getElementById('phonebook');
    document.getElementById('btnLoad').addEventListener('click', loadFunc);
    document.getElementById('btnCreate').addEventListener('click', createFunc);

    async function loadFunc() {
        phoneBook.innerHTML = '';

        let response = await fetch(url);
        let data = await response.json();

        for (const item of Object.values(data)) {
            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deleteFunc);

            let liElement = document.createElement('li');
            liElement.id = item._id;
            liElement.textContent = `${item.person}: ${item.phone}`;
            liElement.appendChild(deleteBtn);
            phoneBook.appendChild(liElement);
        }
    };

    async function createFunc() {
        let person = document.getElementById('person').value;
        let phone = document.getElementById('phone').value;
        
        await fetch(url, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({person, phone})
        });

        person.value = '';
        phone.value = '';
        loadFunc();
    };

    async function deleteFunc(e) {
        let id = e.target.parentElement.id;

        await fetch(`${url}/${id}`, {
            method: 'delete'
        });
    };
}

attachEvents();