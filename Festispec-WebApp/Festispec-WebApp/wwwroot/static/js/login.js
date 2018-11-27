const uri = "/Users/";

function check() {
    if (getCookie("jwt_token")) {

        $.ajax({
            url: uri + "VerifyToken/",
            type: "GET",
            accepts: "application/json",
            contentType: "application/json",
            headers: {
                'Authorization': `Bearer ${getCookie("jwt_token")}`,
            },
            success: function (result) {
                console.log("I'm logged in!")
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log("I'm not logged in?");
            }
        });
    }
}

function authenticate(item) {
    // let form = document.getElementById("Login").value;
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
