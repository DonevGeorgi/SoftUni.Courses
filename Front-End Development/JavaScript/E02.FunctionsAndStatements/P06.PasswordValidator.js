function PasswordValidator(password) {

    let isTrue = true;

    if(password.length < 6 || password.length > 10){
        isTrue = false;
        console.log("Password must be between 6 and 10 characters");
    }

    if(!password.match(/^[A-Za-z0-9]+$/)){
        isTrue = false; 
        console.log("Password must consist only of letters and digits");
    }

    if(!password.match(/\d{2,}/)){
        isTrue = false;
        console.log("Password must have at least 2 digits");
    }

    if(isTrue){
        console.log("Password is valid");
    }
}

PasswordValidator('logIn');