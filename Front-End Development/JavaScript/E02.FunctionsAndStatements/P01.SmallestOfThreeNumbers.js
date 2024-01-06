function SmallesOfThreeNumbers(numOne,numTwo,numThree){
    if(numOne < numTwo && numOne < numThree){
        console.log(numOne);
    }
    else if(numOne > numThree && numTwo > numThree){
        console.log(numThree);
    }
    else{
        console.log(numTwo);
    }
}

SmallesOfThreeNumbers(2,
    2,
    2);