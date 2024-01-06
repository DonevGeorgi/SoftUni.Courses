function MakeMatrixFormNum(number){
    for (let index = 0; index < number; index++) {
        let row = [];
        for (let index = 0; index < number; index++) {
            row.push(number);
        }
        console.log(row.join(" "));
    }
}

MakeMatrixFormNum(7);