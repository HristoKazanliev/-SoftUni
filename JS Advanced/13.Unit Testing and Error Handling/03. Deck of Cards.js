function printDeckOfCards(cards) {
    function createCard(face, suit) {
        const facesEnum = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suitsEnum = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        };
    
        if (!facesEnum.includes(face) || suitsEnum[suit] == undefined) {
            throw new Error();
        }
    
        let result = {
            face, 
            suit: suitsEnum[suit],
            toString() {
                return this.face + this.suit;
            }
        };
    
        return result
    }
    

    let deck = [];
    for (let card of cards) {
        let face = card.slice(0, -1);
        let suit = card.slice(-1);

        try {
            let newCard = createCard(face, suit);
            deck.push(newCard);
        } catch (error) {
            console.log(`Invalid card: ${face + suit}`);
            return
        }
    }

    console.log(deck.join(' '));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);