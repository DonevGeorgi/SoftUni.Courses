function PrimitiveLoadingBar(number){
    let loaginString = '';

    if(number === 100){
        console.log("100% Complete!");
    }
    else {
        switch(number){
            case 10: loaginString = '[%.........]'; break;
            case 20: loaginString = '[%%........]'; break;
            case 30: loaginString = '[%%%.......]'; break;
            case 40: loaginString = '[%%%%......]'; break;
            case 50: loaginString = '[%%%%%.....]'; break;
            case 60: loaginString = '[%%%%%%....]'; break;
            case 70: loaginString = '[%%%%%%%...]'; break;
            case 80: loaginString = '[%%%%%%%%..]'; break;
            case 90: loaginString = '[%%%%%%%%%.]'; break;
        }

        console.log(`${number}% ${loaginString}`);
        console.log("Still loading...");
    }
}

PrimitiveLoadingBar(100);