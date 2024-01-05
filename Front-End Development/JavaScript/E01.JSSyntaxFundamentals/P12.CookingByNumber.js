function DifferentOperationWhitNumber(theNumber,operationOne,operationTwo,operationThree,operationFour,operationFive){

    let number = Number(theNumber);
    const operations = [operationOne,operationTwo,operationThree,operationFour,operationFive];

    for (let index = 0; index <= operations.length - 1; index++) {

        if(operations[index] === 'chop'){
            number /= 2;
        }
        else if(operations[index] === 'dice'){
            number = Math.sqrt(number);
        }
        else if(operations[index] === 'spice'){
            number += 1;
        }
        else if(operations[index] === 'bake'){
            number *= 3;
        }
        else if(operations[index] === 'fillet'){
            number -= number * 0.20;
        }

        console.log(number);
    }
}

DifferentOperationWhitNumber('9', 'dice', 'spice', 'chop', 'bake',
'fillet'
);