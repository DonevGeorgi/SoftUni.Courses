window.addEventListener("load", solve);

function solve() {
  const studentName = document.querySelector("#student");
  const university = document.querySelector("#university");
  const score = document.querySelector("#score");

  const nextButton = document.querySelector("#next-btn");
  const listElement = document.querySelector("#preview-list");
  const candindateList = document.querySelector("#candidates-list");

  nextButton.addEventListener("click", (e) => {
    const currStudent = studentName.value;
    const currUniversity = university.value;
    const currScore = score.value;

    if (currStudent === ""
      || currUniversity === ""
      || currScore === "") {
      return;
    }

    const newLi = document.createElement("li");
    newLi.className = "application";

    const studentH4 = document.createElement("h4");
    studentH4.textContent = `${currStudent}`;
    const universityP = document.createElement("p");
    universityP.textContent = `University: ${currUniversity}`;
    const scoreP = document.createElement("p");
    scoreP.textContent = `Score: ${currScore}`;

    const editButton = document.createElement("button");
    editButton.textContent = "edit";
    editButton.className = "action-btn edit";
    const applyButton = document.createElement("button");
    applyButton.textContent = "apply";
    applyButton.className = "action-btn apply";

    editButton.addEventListener("click", (e) => {
      document.querySelector("#student").value = currStudent;
      document.querySelector("#university").value = currUniversity;
      document.querySelector("#score").value = currScore;
      nextButton.disabled = false;
      listElement.removeChild(newLi);
    });

    applyButton.addEventListener("click", (e) => {
      listElement.removeChild(newLi);
      newLi.removeChild(editButton);
      newLi.removeChild(applyButton);
      candindateList.appendChild(newLi);
      nextButton.disabled = false;
    });

    const newArticle = document.createElement("article");
    newArticle.style.flex;

    newArticle.appendChild(studentH4);
    newArticle.appendChild(universityP);
    newArticle.appendChild(scoreP);

    newLi.appendChild(newArticle);
    newLi.appendChild(editButton);
    newLi.appendChild(applyButton);

    listElement.appendChild(newLi);

    nextButton.disabled = true;

    document.querySelector("#student").value = "";
    document.querySelector("#university").value = "";
    document.querySelector("#score").value = "";
  });
}
