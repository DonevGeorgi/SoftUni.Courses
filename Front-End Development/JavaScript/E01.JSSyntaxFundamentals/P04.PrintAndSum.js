function PrintTheSumFromInput(numberStart, numberEnd){
    let sumArray = [];
    let sum = 0;

    for (let index = numberStart; index <= numberEnd; index++) {
        sumArray.push(index);
        sum += index;
    }

    console.log(sumArray.join(" "));
    console.log(`Sum: ${sum}`);
}

PrintTheSumFromInput(0, 26);