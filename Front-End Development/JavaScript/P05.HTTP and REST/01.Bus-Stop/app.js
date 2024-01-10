async function getInfo() {
    const bussStopID = document.querySelector('#stopId').value;

    try{
        const response = await(await fetch(`http://localhost:3030/jsonstore/bus/businfo/${bussStopID}`)).json();

        const stopName = document.querySelector("#stopName");
        stopName.textContent = response.name;
    
        
        const list = document.querySelector("ul");
        list.innerHTML = "";
    
        Object.entries(response.buses).forEach( ([busID,time]) => {
            const item = document.createElement("li");
            item.textContent = `Bus ${busID} arrives in ${time} minutes`;
            list.appendChild(item);
        })
    }
    catch(error){
        stopName.textContent = "Error";
    }
}