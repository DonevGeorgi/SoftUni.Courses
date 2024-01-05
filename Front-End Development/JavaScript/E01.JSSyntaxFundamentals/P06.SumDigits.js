function SumTheDigitOfGivenNumber(number){

    let sum = 0;
    let digit = number.toString();

    for (let index = 0; index < digit.length; index++) {
        sum += parseInt(digit[index]);
    }

    console.log(sum);
}

SumTheDigitOfGivenNumber(245678);