function PalindromeCheker(numbers){

    for (let index = 0; index < numbers.length; index++) {

        let currNumber = numbers[index];
        let currNumberString = currNumber.toString().split("");
        currNumberString = currNumberString.reverse().join("");
        let numberBackward = Number(currNumberString);
        
        if(currNumber === numberBackward){
            console.log(true);
        }
        else {
            console.log(false);
        }
        
    }
}

PalindromeCheker( [32,2,232,1010]);