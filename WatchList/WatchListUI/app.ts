/// <reference path="Constants.ts"/>
/// <reference path="Models/UserCredentials.ts"/>
class Login {
    init() : void{
        Login.initializeEvents();
    }

    static initializeEvents() : void{
        $(WatchListConstants.ControlConstants.Selector.loginSubmitBTN).bind('click',function(){
            Login.authenticateUser();
        });
    }

    static authenticateUser(): boolean {
        var userName:string = $(WatchListConstants.ControlConstants.Selector.userID).val().toString();
        var password: string = $(WatchListConstants.ControlConstants.Selector.pass).val().toString();
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
                if (data.IsSucceed)
                {
                    $(WatchListConstants.ControlConstants.Selector.loginErrorMessage).css("display","none");
                    window.location.href = "Dashboard.html";
                } else{
                    $(WatchListConstants.ControlConstants.Selector.loginErrorMessage).css("display","block");
                }
                
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
                alert("operation failed");
            }
        });
        return false;
    }
}