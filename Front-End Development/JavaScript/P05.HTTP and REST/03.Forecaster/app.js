async function attachEvents() {
    const response = await ( await fetch("http://localhost:3030/jsonstore/forecaster/locations")).json();

    const button = document.querySelector("submit"); 
    button.addEventListener("click", GettingWeatherData() => {
        
    })
    

}

attachEvents();