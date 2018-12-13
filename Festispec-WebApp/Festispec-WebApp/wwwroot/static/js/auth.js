function checkIfLoggedIn() {
    checkJWT(function (bool) {
        if(!bool) {
            window.location.href = 'login.html';
        } else {
            document.body.style.display = "inline";
        }
    });
}

function logout() {
    eraseCookie("jwt_token");
    setCookie("user_id");
    checkIfLoggedIn();
}