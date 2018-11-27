function checkIfLoggedIn() {
    check(function (bool) {
        if(!bool) {
            window.location.href = 'login.html';
        } else {
            document.body.style.display = "inline";
        }
    });

}