/// <reference path="Constants.ts"/>
/// <reference path="Models/UserCredentials.ts"/>
/// <reference path="Models/Result.ts"/>
var Login = /** @class */ (function () {
    function Login() {
    }
    Login.prototype.init = function () {
        Login.initializeEvents();
    };
    Login.initializeEvents = function () {
        $(WatchListConstants.ControlConstants.Selector.loginSubmitBTN).bind('click', function () {
            Login.authenticateUser();
        });
    };
    Login.authenticateUser = function () {
        var userName = $(WatchListConstants.ControlConstants.Selector.userID).val().toString();
        var password = $(WatchListConstants.ControlConstants.Selector.pass).val().toString();
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
                if (data.IsSucceed) {
                    Login.result = data;
                    $(WatchListConstants.ControlConstants.Selector.loginErrorMessage).hide();
                    localStorage.setItem('watchListSecureToken', Login.result.Messages[0]);
                    window.location.href = "Dashboard.html";
                }
                else {
                    $(WatchListConstants.ControlConstants.Selector.loginErrorMessage).show();
                }
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