const messageRepository = "http://localhost:3030/jsonstore/messenger";

function attachEvents() {
    const selectors = {
        submitButton: document.querySelector("#submit"),
        refreshButton: document.querySelector("#refresh"),
    };
    
    const inputSelectors = {
        nameInput: document.querySelector('input[name="author"]'),
        contentInput: document.querySelector('input[name="content"]'),
        textArea: document.querySelector("#messages"),
    };

    selectors.submitButton.addEventListener("click",sendinMessages);
    selectors.refreshButton.addEventListener("click",gettingMessages)

    async function sendinMessages(){
        const author = inputSelectors.nameInput.value;
        const content = inputSelectors.contentInput.value;

        const response = await fetch(messageRepository, {
            method: "POST",
            body: JSON.stringify({author,content}),
        })

        inputSelectors.nameInput.value = '';
        inputSelectors.contentInput.value = '';
    }
    async function gettingMessages(){
        const response = await ( await fetch(messageRepository)).json();
        
        inputSelectors.textArea.textContent = '';

        Object.values(response).forEach(message => {
            inputSelectors.textArea.textContent += `${message.author}: ${message.content}\n`
        });
    }
}


attachEvents();