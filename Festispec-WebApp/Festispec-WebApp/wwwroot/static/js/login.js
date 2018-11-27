const uri = "/Users/";

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
