function attachEvents() {
    const loadBtn = document.getElementById('btnLoadPosts');
    loadBtn.addEventListener('click', showPosts);
    const viewBtn = document.getElementById('btnViewPost');
    viewBtn.addEventListener('click', showComments);
}

async function showPosts() {
    const response = await fetch(`http://localhost:3030/jsonstore/blog/posts`);
    const data = await response.json();
    
    const selectPosts = document.getElementById('posts');
    selectPosts.innerHTML = '';
    Object.values(data).forEach(post => {
        const option = document.createElement('option');
        option.value = post.id;
        option.textContent = post.title;
        selectPosts.appendChild(option);
    })
}

async function showComments() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';
    const selectedId =  document.querySelector('#posts').value;
    const titleElement = document.getElementById('post-title');
    const pElement = document.getElementById('post-body');
    const commentsUl = document.querySelector('#post-comments');
    commentsUl.innerHTML = '';

    let postResponse = await fetch(`${postsUrl}/${selectedId}`);
    let postData = await postResponse.json();

    let commentsResponse = await fetch(`${commentsUrl}`);
    let commentsData = Object.values(await commentsResponse.json());
    
    titleElement.textContent = postData.title;
    pElement.textContent = postData.body;

    commentsData.forEach(comment => {
        if (comment.postId === selectedId) {
            let listElement = document.createElement('li');
            listElement.id = comment.id;
            listElement.textContent = comment.text;
            commentsUl.appendChild(listElement);
        }
    })
}

attachEvents();