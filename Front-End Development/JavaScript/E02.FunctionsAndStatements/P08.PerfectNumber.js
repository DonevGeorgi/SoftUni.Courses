function IsTheNumberPerfect(number){
    let sum = 0;

    if(number <= 0){
        return console.log("It's not so perfect.");
    }

    for (let index = 1; index < number; index++) {
        if(number % index === 0){
            sum += index;
        }
    }

    if(sum === number){
        console.log("We have a perfect number!");
    }
    else {
        console.log("It's not so perfect.")
    }
}

IsTheNumberPerfect(0);