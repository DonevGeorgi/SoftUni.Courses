function TurningNumberToOddAndEvenSum(number) {

    let stringOfTheNumber = number.toString();
    let sumOfOdds = 0;
    let sumOfEvens = 0;

    for (let index = 0; index < stringOfTheNumber.length; index++) {
            
        let currNumber = Number(stringOfTheNumber[index]);

        if(currNumber % 2 === 0){
            sumOfEvens += currNumber
        }
        else if(currNumber % 2 === 1){
            sumOfOdds += currNumber
        }

    }

    console.log(`Odd sum = ${sumOfOdds}, Even sum = ${sumOfEvens}`);
}

TurningNumberToOddAndEvenSum(3495892137259234);