function ParkingTracker(input) {
    const inTheParking = [];

    input.forEach(curr => {
        const [command, carNumber] = curr.split(", ");

        if(command === 'IN' && !inTheParking.includes(carNumber)){
            inTheParking.push(carNumber);
        }
        else if(command === 'OUT' && inTheParking.includes(carNumber)){
            let index = inTheParking.indexOf(carNumber);
            inTheParking.splice(index,1);
        }
    });

    if(inTheParking.length === 0){
        return console.log("Parking Lot is Empty");
    }

    inTheParking.sort().forEach( car => console.log(car))
}

ParkingTracker(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
);

ParkingTracker(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
);