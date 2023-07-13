class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        let uniquePlayers = new Set();

        for (let player of footballPlayers) {
            let [name, age, playerValue] = player.split('/');

            let existingPlayer = this.invitedPlayers.find(v => v.name === name);
            if (existingPlayer) {
                if (playerValue > existingPlayer.playerValue) {
                    existingPlayer.playerValue = playerValue;
                }
            } else {
                this.invitedPlayers.push({ name, age, playerValue});
            }
            uniquePlayers.add(name);
        }

        return `You successfully invite ${Array.from(uniquePlayers).join(', ')}.`;
    }

    signContract(selectedPlayer) {
            let [name, playerOffer] = selectedPlayer.split('/');

            let existingPlayer = this.invitedPlayers.find(v => v.name === name);
            if (!existingPlayer) {
                throw new Error(`${name} is not invited to the selection list!`);
            }

            if (playerOffer < existingPlayer.playerValue) {
                let priceDifference = existingPlayer.playerValue - playerOffer;
                throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`);
            }

            existingPlayer.playerValue = 'Bought';

            return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`
        
    }

    ageLimit(name, age) {
        let existingPlayer = this.invitedPlayers.find(v => v.name === name);
        if (!existingPlayer) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        let ageDifference  = age - existingPlayer.age;
        if (existingPlayer.age >= age) {
            return `${name} is above age limit!`;
        } 
        if (ageDifference < 5) {
            return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
        } else if (ageDifference > 5) {
            return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
        } 
        
    }

    transferWindowResult() {
        let output = ["Players list:"];
        this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))
        .map(p => output.push(`Player ${p.name}-${p.playerValue}`));
        return output.join('\n');
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.ageLimit("Lionel Messi", 33 ));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.ageLimit("Pau Torres", 26));
console.log(fTeam.signContract("Kylian Mbappé/240"));


