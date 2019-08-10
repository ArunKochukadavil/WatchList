/// <reference path="Constants.ts"/>
/// <reference path="Models/UserCredentials.ts"/>
class Login {
    authenticateUser(): boolean {
        var userName:string = $('#uid').val().toString();
        var password: string = $('#pass').val().toString();
        var userData: UserCredentials = new UserCredentials();
        userData.uid = userName;
        userData.pass = password;
        var apiUrl: string = WatchListConstants.ControlConstants.WebAPIURL.authUrl;
        $.ajax({
            url: apiUrl,
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: function (data, textStatus, jQxhr) {
                data = JSON.parse(data);
                if (data.IsSucceed)
                {
                    $(document).ready(function () {
                        $("#loginForm").submit();
                    });
                }
                else
                    alert("Invalid Credentials");
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
                alert("operation failed");
            }
        });
        return false;
    }
}