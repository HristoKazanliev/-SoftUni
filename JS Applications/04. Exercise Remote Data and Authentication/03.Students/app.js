async function solve() {
    const url = 'http://localhost:3030/jsonstore/collections/students';

    const form = document.getElementById('form');
    const tbody = document.querySelector('tbody');
    form.addEventListener('submit', submitFunc);

    tbody.innerHTML = '';
    let response = await fetch(url);
    let data = await response.json();
    let allStudents = Object.values(data);

    allStudents.forEach(student => {
        let row = document.createElement('tr');

        for (const item in student) {
            if (item == '_id') continue

            let td = document.createElement('td');
            td.textContent = student[item];
            row.appendChild(td);
        }
        tbody.appendChild(row);
    });

    async function submitFunc(e) {
        e.preventDefault();

        const data = new FormData(form);
        const studentObj = Object.fromEntries(data.entries());

        if (Object.values(studentObj).includes('')) {
            return
        }

        await fetch(url, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(studentObj)
        });
    }
}

solve();