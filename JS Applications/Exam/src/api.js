const host = "http://localhost:3030";

async function request(url, method, data, token) {
    let options = {
        method,
        headers: {},
    };

    if (data !== undefined) {
        options.headers["content-type"] = "application/json";
        options.body = JSON.stringify(data);
    }

    if (token !== undefined) {
        options.headers["X-Authorization"] = token;
    }

    try {
        let response = await fetch(host + url, options);
        if (response.status == 204) {
            return response;
        }
        let data = await response.json();
        if (response.ok == false) {
            throw new Error(data.message);
        }
        return data;
    } catch (error) {
        alert(error.message);
        throw error;
    }
}

export async function onLogin(data) {
    return await request("/users/login", "post", data);
}

export async function onLogout() {
    let token = sessionStorage.token;
    return await request("/users/logout", "get", undefined, token);
}

export async function onRegister(data) {
    let token = sessionStorage.token;
    return await request("/users/register", "post", data, token);
}

export async function getAllAlbums() {
    return await request("/data/albums?sortBy=_createdOn%20desc", "get");
}

export async function onCreate(data) {
    let token = sessionStorage.token;
    return await request("/data/albums", "post", data, token);
}

export async function onDetails(id) {
    return await request("/data/albums/" + id, "get");
}

export async function onDelete(id) {
    let token = sessionStorage.token;
    return await request("/data/albums/" + id, "delete", undefined, token);
}

export async function onUpdate(data, id) {
    let token = sessionStorage.token;
    return await request("/data/albums/" + id, "put", data, token);
}
