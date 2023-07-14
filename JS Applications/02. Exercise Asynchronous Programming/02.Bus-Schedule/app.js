function solve() {
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const infoElement = document.getElementsByClassName('info')[0];
    const url = 'http://localhost:3030/jsonstore/bus/schedule';

    let stopID = 'depot';
    let stopName = '';

    async function depart() {
        const response = await fetch(`${url}/${stopID}`)
        const data =  await response.json();

        stopName = data.name;
        stopID = data.next;
        infoElement.textContent = `Next stop ${stopName}`;

        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function arrive() {
        infoElement.textContent = `Arriving at ${stopName}`;

        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();