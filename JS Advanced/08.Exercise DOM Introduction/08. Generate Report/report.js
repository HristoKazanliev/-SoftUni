function generateReport() {
    let tableHeader = document.querySelectorAll('thead tr th input');
    let tableRow = document.querySelectorAll('tbody tr');
    let result = [];

    for (let i = 0; i < tableRow.length; i++) {
        let currData = {};

        for (let j = 0; j < tableHeader.length; j++) {
            if (tableHeader[j].checked) {
                currData[tableHeader[j].name] = tableRow[i].children[j].textContent;
            }
        }

        result.push(currData);
    }

    let jsonResult = JSON.stringify(result);
    document.getElementById('output').textContent = jsonResult;
}