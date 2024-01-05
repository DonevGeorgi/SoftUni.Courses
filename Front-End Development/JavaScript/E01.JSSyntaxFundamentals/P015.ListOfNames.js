function SortingArrayOfNames(arr){
    let count = 1;
    arr.sort();
    arr.forEach(element => {
        console.log(count + "." + element);
        count++;
    });
}

SortingArrayOfNames([]
);