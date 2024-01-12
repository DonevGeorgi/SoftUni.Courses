const nameInput = document.querySelector("#name");
const daysInput = document.querySelector("#num-days");
const dateInput = document.querySelector("#from-date");

const loadAllButton = document.querySelector("#load-vacations");
const addVacationButton = document.querySelector("#add-vacation");
const editVacationButton = document.querySelector("#edit-vacation");
const vacationDisplayDiv = document.querySelector("#list");

loadAllButton.addEventListener("click", loadingAllVacations);
addVacationButton.addEventListener("click", async (e) => {
    e.preventDefault();
    const currName = nameInput.value;
    const currDays = daysInput.value;
    const currDate = dateInput.value;

    await fetch("http://localhost:3030/jsonstore/tasks/", {
        method: "POST",
        body: JSON.stringify(
            {
                name: currName,
                days: currDays,
                date: currDate
            })
    })

    loadingAllVacations();
    document.querySelector("#name").value = "";
    document.querySelector("#num-days").value = "";
    document.querySelector("#from-date").value = "";
});

async function loadingAllVacations() {
    const response = await (await fetch("http://localhost:3030/jsonstore/tasks/")).json();

    vacationDisplayDiv.innerHTML = "";

    Object.values(response).forEach(vacation => {

        const div = document.createElement("div");
        div.className = "container";
        const nameH2 = document.createElement("h2");
        nameH2.textContent = `${vacation.name}`;
        const dateH3 = document.createElement("h3");
        dateH3.textContent = `${vacation.date}`;
        const daysH3 = document.createElement("h3");
        daysH3.textContent = `${vacation.days}`;

        const changeButton = document.createElement("button");
        changeButton.textContent = "Change";
        changeButton.className = "change-btn";
        const doneButton = document.createElement("button");
        doneButton.textContent = "Done";
        doneButton.className = "done-btn";

        changeButton.addEventListener("click", (e) => {
            vacationDisplayDiv.removeChild(div);

            editVacationButton.addEventListener("click", async (e) => {
                e.preventDefault();

                const currName = nameInput.value;
                const currDays = daysInput.value;
                const currDate = dateInput.value;

                await fetch(`http://localhost:3030/jsonstore/tasks/${vacation._id}`, {
                    method: "PUT",
                    body: JSON.stringify({
                        name: currName,
                        days: currDays,
                        date: currDate
                    })
                })

                loadingAllVacations();
                editVacationButton.setAttribute("disabled", true);
                addVacationButton.removeAttribute("disabled");
                document.querySelector("#name").value = "";
                document.querySelector("#num-days").value = "";
                document.querySelector("#from-date").value = "";
            });

            editVacationButton.removeAttribute("disabled");
            addVacationButton.setAttribute("disabled", true);
            document.querySelector("#name").value = vacation.name;
            document.querySelector("#num-days").value = vacation.days;
            document.querySelector("#from-date").value = vacation.date;
        });

        doneButton.addEventListener("click", async(e) => {
            await fetch(`http://localhost:3030/jsonstore/tasks/${vacation._id}`,{
                method: "DELETE",
                body: undefined
            })

            loadingAllVacations();
        });

        div.appendChild(nameH2);
        div.appendChild(dateH3);
        div.appendChild(daysH3);
        div.appendChild(changeButton);
        div.appendChild(doneButton);

        vacationDisplayDiv.appendChild(div);
    });
}