function OddApearences(input) {

    const inputData = input.toLowerCase().split(" ");

    let output = ' ';

    inputData.forEach(curr => {
        count = 0;

        inputData.forEach( word => {
            if(word === curr){
                count++;
            }
        });

        if(count % 2 === 1 && !output.includes(curr)){
            output += " " + curr;
        }
    });

    console.log(output);
}

OddApearences('Java C# Php Java PhP 3 3 1 1 5 5 C#');