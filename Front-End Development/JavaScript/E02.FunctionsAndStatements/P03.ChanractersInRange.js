function CharactersInRange(firstCharacter,secondCharacter) {
    let startCode = firstCharacter.codePointAt();
    let endCode = secondCharacter.codePointAt();

    if(startCode > endCode){
        let transferVariable = startCode;
        startCode = endCode;
        endCode = transferVariable;
    }

    let range = [];
    for (let index = startCode + 1; index < endCode; index++) {
        range.push(String.fromCharCode(index));
    }

    console.log(range.join(" "));
} 

CharactersInRange('C',
'#');