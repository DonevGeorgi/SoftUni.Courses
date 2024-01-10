let responsePosts;

function attachEvents() {
    const loadPostsButton = document.querySelector("#btnLoadPosts");
    const viewPostsButton = document.querySelector("#btnViewPost");

    loadPostsButton.addEventListener("click", fetchingAndLoadingAllPost);
    viewPostsButton.addEventListener("click", displayAllPostClientPick);
}

async function fetchingAndLoadingAllPost(){
    const posts = document.querySelector("#posts");

    responsePosts = await ( await fetch("http://localhost:3030/jsonstore/blog/posts")).json();
    
    Object.values(responsePosts).forEach(message => {
        const newOption = document.createElement("option");
        newOption.value = message.id;
        newOption.text = message.title;
        posts.appendChild(newOption);
    });
}

async function displayAllPostClientPick(){
    const postTitle = document.querySelector("#post-title");
    const postBody = document.querySelector("#post-body");
    const list = document.querySelector("#post-comments");

    postTitle.innerHTML = "";
    postBody.innerHTML = "";
    list.innerHTML = "";

    const selectedPost = document.querySelector("#posts").value;
    const response = await (await fetch("http://localhost:3030/jsonstore/blog/comments")).json();

    const comments = Object.values(response).filter((comment) =>comment.postId === selectedPost);

    const currPost = Object.values(responsePosts).find((post) => post.id === selectedPost);
    postBody.textContent = currPost.body;
    postTitle.textContent = currPost.title;

    Object.values(comments).forEach(comment => {
        const currListElement = document.createElement("li");
        currListElement.textContent = comment.text;

        list.appendChild(currListElement);
    });
}

attachEvents();