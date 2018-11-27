const uri = "/Users/";

function check(callback) {
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
                return callback(true);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                eraseCookie("jwt_token");
                return callback(false);
            }
        });
    } else {
        return callback(false);
    }
}