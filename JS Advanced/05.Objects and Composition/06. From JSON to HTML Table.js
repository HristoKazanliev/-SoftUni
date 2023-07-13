function solve(input) {
    let jsonParsed = JSON.parse(input);
    let columnNames = Object.keys(jsonParsed[0]);

    let newArray = ['<table>'];
    newArray.push(headerRow(columnNames));
    jsonParsed.forEach((element) => newArray.push(valueRow(element)));
    newArray.push('</table>');

    console.log(newArray.join('\n'));

    function headerRow(columnNames) {
        let result = '    <tr>';
        for (let column of columnNames) {
            result += `<th>${escapeHTML(column)}</th>`;
        }
        result += '</tr>';

        return result;
    }

    function valueRow(values) {
        let result = '    <tr>';
        Object.values(values).forEach(element => {
            result += `<td>${escapeHTML(element)}</td>`;
        });
        result += '</tr>';

        return result;
    }

    function escapeHTML(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

solve(`[{"Name":"Stamat",
        "Score":5.5},
        {"Name":"Rumen",
        "Score":6}]`);

solve(`[{"Name":"Pesho",
        "Score":4,
        " Grade":8},
        {"Name":"Gosho",
        "Score":5,
        " Grade":8},
        {"Name":"Angel",
        "Score":5.50,
        " Grade":10}]`);        