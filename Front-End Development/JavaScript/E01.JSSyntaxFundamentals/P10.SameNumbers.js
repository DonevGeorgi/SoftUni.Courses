function IsAllNumberTheSame(number){

    let numberArr = number.toString().split("").map(Number);

        if(number === 0){
            console.log(true);
        }   
        else if(numberArr.every(x => x === numberArr[1])){
            console.log(true);
        }
        else {
            console.log(false);
        }
    
        console.log(numberArr.reduce((acumulator,currValue) => acumulator + currValue));
    
}

IsAllNumberTheSame(0);