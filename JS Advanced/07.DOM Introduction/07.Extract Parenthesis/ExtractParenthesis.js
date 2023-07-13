function extract(content) {
    let targetElement = document.getElementById(content).textContent;
    const pattern  = /\((.+?)\)/g;

    let result = targetElement.matchAll(pattern);
    let matchesArray = [];
    for (const match of result) {
        matchesArray.push(match[1]);
    }
    
    return matchesArray.join('; ');
}
