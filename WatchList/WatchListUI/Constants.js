var WatchListConstants;
(function (WatchListConstants) {
    var ControlConstants;
    (function (ControlConstants) {
        var Selector = /** @class */ (function () {
            function Selector() {
            }
            Selector.userID = "#uid";
            Selector.pass = "#pass";
            Selector.loginSubmitBTN = "#LoginSubmitBTN";
            Selector.loginErrorMessage = "#LoginErrorMessage";
            Selector.dashboardWatchListDataTable = "#table_data";
            Selector.loader = "#loader";
            return Selector;
        }());
        ControlConstants.Selector = Selector;
        var WebAPIURL = /** @class */ (function () {
            function WebAPIURL() {
            }
            WebAPIURL.authUrl = "http://localhost:89/WatchListAPI/Auth/Login";
            WebAPIURL.getWatchData = "http://localhost:89/WatchListAPI/WatchData/Get?uid=";
            return WebAPIURL;
        }());
        ControlConstants.WebAPIURL = WebAPIURL;
    })(ControlConstants = WatchListConstants.ControlConstants || (WatchListConstants.ControlConstants = {}));
})(WatchListConstants || (WatchListConstants = {}));
//# sourceMappingURL=Constants.js.map