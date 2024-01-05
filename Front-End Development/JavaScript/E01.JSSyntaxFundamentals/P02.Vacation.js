function CalculatingVacationBudget(peopleNumber, groupType, dayOfTheWeek){

    let totalPrice = 0;

    if(groupType === "Students") {

        if(dayOfTheWeek === "Friday"){
            totalPrice = peopleNumber * 8.45;
        }
        else if(dayOfTheWeek === "Saturday"){
            totalPrice = peopleNumber * 9.80;
        }
        else if(dayOfTheWeek === "Sunday"){
            totalPrice = peopleNumber * 10.46;
        }

        if(peopleNumber >= 30){
            totalPrice -= totalPrice * 0.15;
        }
    }
    else if(groupType === "Business") {

        if(peopleNumber >= 100){
            peopleNumber -= 10;
        }

        if(dayOfTheWeek === "Friday"){
            totalPrice = peopleNumber * 10.90;
        }
        else if(dayOfTheWeek === "Saturday"){
            totalPrice = peopleNumber * 15.60;
        }
        else if(dayOfTheWeek === "Sunday"){
            totalPrice = peopleNumber * 16;
        }
    }
    else if(groupType === "Regular") {

        if(dayOfTheWeek === "Friday"){
            totalPrice = peopleNumber * 15;
        }
        else if(dayOfTheWeek === "Saturday"){
            totalPrice = peopleNumber * 20;
        }
        else if(dayOfTheWeek === "Sunday"){
            totalPrice = peopleNumber * 22.50;
        }

        if(peopleNumber >= 10 && peopleNumber <= 20){
            totalPrice -= totalPrice * 0.05;
        }
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

CalculatingVacationBudget(30,"Students","Sunday");