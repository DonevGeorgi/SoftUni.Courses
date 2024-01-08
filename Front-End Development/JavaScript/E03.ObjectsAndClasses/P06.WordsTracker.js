// function WordTracking(input) {
//     const wordsToTrack = input[0].split(" ");
//     const wordsToBeTracked = input.slice(1);
    
//     let wordOcurred = [];
    
//     wordsToTrack.forEach(word => {
//         let count = 0;
        
//         wordsToBeTracked.forEach( (curr) => {
//             if(curr === word){
//                 count++;
//             }
//         })
        
//         const currWord = {
//             word: word,
//             count: count 
//         }

//         wordOcurred.push(currWord);
//     });

//     wordOcurred.sort((a, b) => a.count < b.count ? 1 : -1)
//     .forEach( word => console.log(`${word.word} - ${word.count}`))
// }

function WordTracking(input) {
    const [searchWord,...words] = input;

    const wordOccurances = searchWord.split(" ").reduce( (acc,curr) => {
        acc[curr] = 0;
        return acc;
    }, {})

    words.forEach(word => {
        if(wordOccurances.hasOwnProperty(word)){
            wordOccurances[word] += 1;
        }
    });

    Object.entries(wordOccurances).sort(([words1,count1],[words2,count2]) => count2 - count1).forEach( (key) => {
    console.log(`${key} - ${wordOccurances[key]}`);
   })
}

WordTracking([
    'this sentence the',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task', 'the','the'
    ]);

    WordTracking([
'is the',
'first', 'sentence', 'Here', 'is',
'another', 'the', 'And', 'finally', 'the',
'the', 'sentence']
);