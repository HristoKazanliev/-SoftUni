function solve(input, criteria) {
    class Ticket {
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let ticketResult = [];
    for (let obj of input) {
        let [destination, price, status] = obj.split('|');
        ticketResult.push(new Ticket(destination, Number(price), status));
    }

    let sorted;
    criteria == 'price' ? sorted = ticketResult.sort((a, b) => a[criteria] - b[criteria]) : sorted = ticketResult.sort((a, b) => a[criteria].localeCompare(b[criteria]));

    return sorted;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination');

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'price');