function getArticleGenerator(articles) {
    let articlesArray = articles;

    let showNext = () =>{
        let contentElement = document.getElementById('content');
        let article = document.createElement('article');
        if (articlesArray.length > 0) {
            article.textContent = articles.shift();
            contentElement.appendChild(article);
        }
    };

    return showNext;
}
