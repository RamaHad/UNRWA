let emailInput = document.getElementById("email");
let passwordInput = document.getElementById("password");
let submitBtn = document.getElementById("submit-btn");
let emailErrorMessage = document.getElementById("email-error-message");
let passwordErrorMessage = document.getElementById("password-error-message");
let faildLoginSpan = document.getElementById("faild-login");
let faildLoginText = document.createTextNode("Infalid Email Or Password !")
document.forms[0].onsubmit = function (e) {
    let emailValid = false;
    let passwordValid = false;

    if (emailInput.value !== "") {
        emailValid = true;
        emailInput.className = "valid";
        emailErrorMessage.className = "Valid-Message";
      
    }
    else {
        emailInput.className = "error";
        emailErrorMessage.className = "Error-Message";
    }
    if (passwordInput.value !== "") {
        passwordValid = true;
        passwordInput.className = "valid";
        passwordErrorMessage.className = "Valid-Message"

    }
    else {
        passwordInput.className = "error";
        passwordErrorMessage.className = "Error-Message"
    }
    if (passwordValid === false || emailValid === false) {
        e.preventDefault();
    }
    else {
        e.preventDefault();
        $.ajax({
            url: '/UsersManager/Login',
            type: "POST",
            data: {
                Email: emailInput.value,
                Password: passwordInput.value
            },
            success: function (result) {
                if (result === false) {

                    faildLoginSpan.className = "faild-login";
                    faildLoginSpan.appendChild(faildLoginText);
                    emailInput.className = "normal-input";
                    passwordInput.className = "normal-input";
                    emailErrorMessage.className = "normal-validation-message";
                    passwordErrorMessage.className = "normal-validation-message";
                    passwordInput.value = "";
                }
                else {
                    $.ajax({
                        url: '/UsersManager/RedirectTheUser',
                        type: "POST",
                        data: {
                            Email: emailInput.value,
                            Password: passwordInput.value
                        },
                        success: function (response) {
                            document.forms[0].innerHTML = ' <div id="loading"> </div > ';

                            window.location.href = response.redirectUrl;

                        }
                    });
                }
            },
            error: function (result) {
                console.log("faild login");
            }
        }
        );
    }
}


