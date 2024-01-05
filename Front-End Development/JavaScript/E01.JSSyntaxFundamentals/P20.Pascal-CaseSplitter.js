function PascalCaseSpliter(text){
    const words = text.split(/([A-Z][a-z0-9]+)/).filter(e => e !== "");

    console.log(words.join(", "));
}

PascalCaseSpliter('SpliMtsdsd232MeIfYouCanHaHaYouCantOrYouCan');