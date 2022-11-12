function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    document.getElementById('submit').addEventListener('click', submitFunc);
    document.getElementById('refresh').addEventListener('click', refreshFunc);  
    const textAreaElement = document.getElementById('messages');

    async function submitFunc() {
        let author = document.querySelector("input[name='author']").value;
        let content = document.querySelector("input[name='content']").value;

        await fetch(url, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({author, content})
        });
    }

    async function refreshFunc() {
        let response = await fetch(url);
        let data = await response.json();
        let text = [];

        for (const message of Object.values(data)) {
            text.push(`${message.author}: ${message.content}`);
        }
        textAreaElement.value = text.join(`\n`);
    }
}

attachEvents();