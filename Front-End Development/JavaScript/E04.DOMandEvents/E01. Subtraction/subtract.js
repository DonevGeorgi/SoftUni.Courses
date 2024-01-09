function subtract() {
    let firstNumber = document.getElementById('firstNumber').value;
    let secondNumber = document.getElementById('secondNumber').value;
    let result = firstNumber - secondNumber;

    const paragraph = document.createElement("p");
    
    paragraph.textContent = result;
    
    let resultDIV = document.getElementById('result');
    resultDIV.appendChild(paragraph);
}