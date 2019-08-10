/// <reference path="Constants.ts"/>
/// <reference path="Models/UserCredentials.ts"/>
var Login = /** @class */ (function () {
    function Login() {
    }
    Login.prototype.authenticateUser = function () {
        var userName = $('#uid').val().toString();
        var password = $('#pass').val().toString();
        var userData = new UserCredentials();
        userData.uid = userName;
        userData.pass = password;
        var apiUrl = WatchListConstants.ControlConstants.WebAPIURL.authUrl;
        $.ajax({
            url: apiUrl,
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: function (data, textStatus, jQxhr) {
                data = JSON.parse(data);
                if (data.IsSucceed) {
                    $(document).ready(function () {
                        $("#loginForm").submit();
                    });
                }
                else
                    alert("Invalid Credentials");
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
                alert("operation failed");
            }
        });
        return false;
    };
    return Login;
}());
//# sourceMappingURL=app.js.map