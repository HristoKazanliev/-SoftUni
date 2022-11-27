const url = 'http://localhost:3030/jsonstore/advanced/table';

export async function get(){
    let response = await fetch(url);
    let data = await response.json();

    return [...Object.values(data)];
}