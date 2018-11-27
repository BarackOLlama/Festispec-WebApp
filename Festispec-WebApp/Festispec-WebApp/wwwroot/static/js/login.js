document.body.style.display = "none";

allowedToLogin();

function allowedToLogin() {
    check(function (bool) {
        if(bool) {
            window.location.href = 'index.html';
        } else {
            document.body.style.display = "inline";
        }
    });
}

function authenticate(item) {
    console.log(item);
    $.ajax({
        url: uri + "authenticate/",
        type: "POST",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            setCookie("jwt_token", result["token"], 7)
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("Something went wrong");
            let error = $("#errorAlert");
            error.fadeIn();
            error.fadeOut(3000);
        }
    });
}

$("#Login").on("submit", function () {
    const item = {
        username: $("#inputEmail").val(),
        password: $("#inputPassword").val()
    };
    authenticate(item);

});
