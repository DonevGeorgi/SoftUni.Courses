function MakingStoreStockList(listOne,listTwo){
    const hwoleList = listOne.concat(listTwo);

    const stockList = hwoleList.reduce( (acc,curr,index) => {
        if (index % 2 === 0) {
            if (!acc.hasOwnProperty(curr)) {
              acc[curr] = Number(hwoleList[index + 1]);
            } else {
              acc[curr] += Number(hwoleList[index + 1]);
            }
          }

        return acc;
    }, {})

    Object.entries(stockList).forEach( (key) => {
        console.log(`${key[0]} -> ${key[1]}`);
    })
}

MakingStoreStockList([
    'Chips', '5', 'CocaCola', '9', 'Bananas',
    '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7',
    'Tomatoes', '70', 'Bananas', '30'
    ]
    );