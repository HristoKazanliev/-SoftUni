function sumTable() {
    const rows = Array.from(document.querySelectorAll('tr')).slice(1, -1);
    let sum = 0;

    for (const row of rows) {
        const value = Number(row.lastElementChild.textContent);
        sum += value;
    }
    
    let resultElement = document.getElementById('sum');
    resultElement.textContent = sum;
}
