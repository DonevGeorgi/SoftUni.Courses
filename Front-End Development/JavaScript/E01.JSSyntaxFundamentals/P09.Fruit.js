function FruitStore(fruit, weight, money) {

    let finalPrice = money * (weight /= 1000);

    console.log(`I need $${finalPrice.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

FruitStore('orange', 2500, 1.80 );