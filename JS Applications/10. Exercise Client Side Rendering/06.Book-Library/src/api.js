const url = 'http://localhost:3030/jsonstore/collections/books'

export async function get(){
    let response = await fetch(url);
    let data = await response.json();

    return [...Object.entries(data)];
}

export async function post({author, title}){
    return await fetch(url, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({author, title})
    });
}

export async function put(id, data){
    return await fetch(`${url}/${id}`, {
        method: 'PUT',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });

}

export async function del(id){
    return await fetch(`${url}/${id}`, {
        method: 'DELETE'
    });
}