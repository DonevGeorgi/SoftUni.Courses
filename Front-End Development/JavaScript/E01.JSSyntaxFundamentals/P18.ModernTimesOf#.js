function HashTagReplacement(text){
    for (let index = 0; index < text.length; index++) {
        
        let currIndex = index;

        if(text[currIndex] === "#"){

            let breakFlag = true;
            let currWord = '';

            for (let index = currIndex + 1; index < text.length; index++) {
                if(text[index].match(/\d+/)){
                    breakFlag = false;
                    break;
                }
                else if(text[index] === " "){
                    break;
                }
                else {
                    currWord += text[index];
                }
            }

            if(breakFlag && currWord.length > 0){
                 console.log(currWord);
            }

        }
    }
}

HashTagReplacement("Nowadays everyone uses #asd2sda to tag a #special word in #socialMedia");