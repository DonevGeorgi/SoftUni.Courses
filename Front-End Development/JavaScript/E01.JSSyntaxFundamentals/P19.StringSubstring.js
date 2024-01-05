function FindingSubstring(word, text){
    let dummyText = text.toLowerCase();

    if(dummyText.match(word)){
        console.log(word);
    }
    else {
        console.log(`${word} not found!`);
    }
}

FindingSubstring('javascript',
'JavaScript is the best programming language');