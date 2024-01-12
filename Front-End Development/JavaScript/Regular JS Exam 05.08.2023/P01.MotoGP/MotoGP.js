const { createDiffieHellmanGroup } = require("crypto");

function solve(input) {
    const n = input.shift();

    let participant = [];

    for (let index = 0; index < n; index++) {

        const currInput = input.shift().split("|");

        const currParticipant = {
            rider: currInput[0],
            fuelCapacity: currInput[1],
            position: currInput[2]
        };

        participant.push(currParticipant);
    }

    let currCommand = input.shift().split(" - ");

    while (currCommand[0] !== "Finish") {

        if (currCommand[0] === "StopForFuel") {
            const currRider = currCommand[1];
            const minimumFuel = currCommand[2];
            const changedPosition = currCommand[3];

            const currParticipant = participant.find(rider => rider.rider === currRider);

            if (Number(currParticipant.fuelCapacity) <= Number(minimumFuel)) {
                Object.values(participant).forEach(participant => {
                    if(participant.rider === currRider){
                        participant.position = changedPosition;
                    }
                })
                console.log(`${currRider} stopped to refuel but lost his position, now he is ${changedPosition}.`)
            }
            else {
                console.log(`${currRider} does not need to stop for fuel!`)
            }
        }
        else if (currCommand[0] === "Overtaking") {
            const firstRider = currCommand[1];
            const secondRider = currCommand[2];

            const firstPostion = participant.find(rider => rider.rider === firstRider);
            const secondPositon = participant.find(rider => rider.rider === secondRider);

            if (Number(firstPostion.position) < Number(secondPositon.position)) {
                const one = secondPositon.position;
                const two = firstPostion.position;

                Object.values(participant).forEach(participant => {
                    if (participant.rider === firstPostion.rider) {
                        participant.position = one;
                    }
                    else if (participant.rider === secondPositon.rider) {
                        participant.position = two;
                    }
                })
                console.log(`${firstRider} overtook ${secondRider}!`);
            }

        }
        else if (currCommand[0] === "EngineFail") {
            const currRider = currCommand[1];
            const lapsLeft = currCommand[2];

            const currParticipant = participant.find(rider => rider.rider === currRider);
            const index = participant.indexOf(currParticipant);
            participant.splice(index, 1);

            console.log(`${currRider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
        }

        currCommand = input.shift().split(" - ");
    }

    participant.sort((a, b) => {
        if (Number(a.position) === Number(b.position)) {
            return b.position - a.position;
        } else {
            return a.position - b.position;
        }
    });

    Object.values(participant).forEach(participant => {
        console.log(`${participant.rider}`);
        console.log(`Final position: ${participant.position}`);
    });
}

// solve(((["3",
// "Valentino Rossi|100|1",
// "Marc Marquez|90|2",
// "Jorge Lorenzo|80|3",
// "StopForFuel - Valentino Rossi - 50 - 1",
// "Overtaking - Marc Marquez - Jorge Lorenzo",
// "EngineFail - Marc Marquez - 10",
// "Finish"])
// )
// );

solve((["4",
"Valentino Rossi|100|1",
"Marc Marquez|90|3",
"Jorge Lorenzo|80|4",
"Johann Zarco|80|2",
"StopForFuel - Johann Zarco - 90 - 5",
"Overtaking - Marc Marquez - Jorge Lorenzo",
"EngineFail - Marc Marquez - 10",
"Finish"])
);