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
            Selector.signOut = "#sign_out";
            Selector.watchDataTable = "#watchDataTable";
            Selector.watchDataTableBody = "#watchDataTableBody";
            return Selector;
        }());
        ControlConstants.Selector = Selector;
        var LocalStorage = /** @class */ (function () {
            function LocalStorage() {
            }
            LocalStorage.tokenKey = "watchListSecureToken";
            return LocalStorage;
        }());
        ControlConstants.LocalStorage = LocalStorage;
        var WebAPIURL = /** @class */ (function () {
            function WebAPIURL() {
            }
            WebAPIURL.authUrl = "http://localhost:89/WatchListAPI/Auth/Login";
            WebAPIURL.getWatchDataUrl = "http://localhost:89/WatchListAPI/WatchData/Get";
            return WebAPIURL;
        }());
        ControlConstants.WebAPIURL = WebAPIURL;
        var Value = /** @class */ (function () {
            function Value() {
            }
            Value.MaxReview = 5;
            return Value;
        }());
        ControlConstants.Value = Value;
    })(ControlConstants = WatchListConstants.ControlConstants || (WatchListConstants.ControlConstants = {}));
})(WatchListConstants || (WatchListConstants = {}));
//# sourceMappingURL=Constants.js.map