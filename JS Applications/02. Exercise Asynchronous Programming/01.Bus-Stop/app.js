async function getInfo() {
    const stopID = document.getElementById('stopId').value;
    const stopName = document.getElementById('stopName');
    const busList = document.getElementById('buses');

    try {
        const response = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopID}`);

        busList.innerHTML = '';
        const data = await response.json();

        stopName.textContent = data.name;
        for (let bus in data.buses) {
            let li = document.createElement('li');
            li.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
            busList.appendChild(li);
        }
    } catch (error) {
        stopName.textContent = 'Error';
        busList.innerHTML = '';
    }
}