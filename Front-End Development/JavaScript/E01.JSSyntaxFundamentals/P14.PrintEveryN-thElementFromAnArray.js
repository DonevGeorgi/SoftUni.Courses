function PringEveryNEllement(array, stepNumber){
    const newArray = [];

    for (let index = 0; index < array.length; index += stepNumber) {
           console.log(array[index]);
    }

    return newArray;
}   

PringEveryNEllement(['5',
'20',
'31',
'4',
'20'],
2);