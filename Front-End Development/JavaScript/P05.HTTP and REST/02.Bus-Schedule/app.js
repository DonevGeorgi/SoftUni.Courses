function solve() {
    let id = "depot";
    let nameOfCurrentStop = '';

    function ChangingDisabilityOfButtons(state) {
        if(state === "departed"){
            const departButton = document.querySelector('#depart').disabled = true;
            const arriveButton = document.querySelector(`#arrive`).disabled = false;
        }
        else if(state === "arrived") {
            const arriveButton = document.querySelector(`#arrive`).disabled = true;
            const departButton = document.querySelector('#depart').disabled = false;
        }
        else if(state === "error") {
            const arriveButton = document.querySelector(`#arrive`).disabled = false;
            const departButton = document.querySelector('#depart').disabled = false;
        }
    }
    function ChangingInfoTab(state){
        const infoField = document.querySelector("#info");
        if(state === "departed"){
            infoField.textContent = `Next stop ${nameOfCurrentStop}`;
        }
        else if(state === "arrived"){
            infoField.textContent = `Arriving at ${nameOfCurrentStop}`;
        }    
        else if(state === "error"){
            infoField.textContent = `Error`;
        }    
    }

    async function depart() {
        try{
            const response = await( await fetch(`http://localhost:3030/jsonstore/bus/schedule/${id}`)).json();
            id = response.next;
            nameOfCurrentStop = response.name;
            ChangingInfoTab("departed");
            ChangingDisabilityOfButtons("departed");
        }
        catch(error){
            ChangingInfoTab("error");
            ChangingDisabilityOfButtons("error");
        }
        
    }

    async function arrive() {

        try{
            ChangingInfoTab("arrived");
            ChangingDisabilityOfButtons("arrived");
        }
        catch(error){
            ChangingInfoTab("error");
            ChangingDisabilityOfButtons("error");
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();