function create(words) {

   let holder = document.getElementById("content");

   words.forEach(word => {
      let currDiv = document.createElement("div");
      let paragraph = document.createElement("p");
      paragraph.textContent = word;
      paragraph.style.display = "none";
      currDiv.appendChild(paragraph)
      currDiv.addEventListener("click",function() {
         paragraph.style.display =  
         paragraph.style.display === "none" ? "block" : "none";
      })
      
      holder.appendChild(currDiv);
   });
   
}