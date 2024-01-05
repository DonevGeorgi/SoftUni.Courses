function ReplacingWords(word, text){

    const words = word.split(", ");
    for (let index = 0; index <= words.length; index++) {
        if(text.match(/[*]+/).length === words.length){
            text = text.replace(/[*]+/,words[index]);
        }
    }

    console.log(text);
}

ReplacingWords('great, learning',
'softuni is ******* place for ****** new programming languages');