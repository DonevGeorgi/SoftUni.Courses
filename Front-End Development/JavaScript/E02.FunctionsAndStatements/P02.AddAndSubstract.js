function AddTwoNumberAndSubstractThird(numOne,numTwo,numThree){
    function sum(numOne,numTwo){
            return numOne + numTwo;
        }
    
    function substract(sum,numThree) {
            return sum - numThree
        }
    let sumOfFirstAndSecondName = sum(numOne,numTwo);
    let result = substract(sumOfFirstAndSecondName,numThree);
    console.log(result);
}