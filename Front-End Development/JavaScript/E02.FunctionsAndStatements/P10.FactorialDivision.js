function FactorialDivision(numberOne, numberTwo) {
    function Factorial(number){
        let sum = 1;
        for (let index = number; index >= 1; index--) {
            sum *= index;
        }

        return sum;
    }

    let factorialOfFirstNum = Factorial(numberOne);
    let factorialOfSecondNum = Factorial(numberTwo);

    let totalSum = factorialOfFirstNum / factorialOfSecondNum;
    console.log(totalSum.toFixed(2));
}

FactorialDivision(5, 2);