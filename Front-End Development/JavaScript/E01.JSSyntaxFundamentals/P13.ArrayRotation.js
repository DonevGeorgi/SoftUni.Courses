function ArrayRotation(array, rotationCount){

    for (let index = 0; index < rotationCount; index++) {
        array.push(array.shift());
    }

    console.log(array.join(" "));
}

ArrayRotation([51, 47, 32, 61, 21], 2);