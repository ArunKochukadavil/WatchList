module WatchListConstants {
    export module ControlConstants {
        export class Selector{
            static readonly userID: string = "#uid";
            static readonly pass: string = "#pass";
            static readonly loginSubmitBTN: string = "#LoginSubmitBTN";
            static readonly loginErrorMessage: string = "#LoginErrorMessage";
            static readonly dashboardWatchListDataTable: string = "#table_data";
            static readonly loader: string = "#loader";
            static readonly signOut = "#sign_out";
            static readonly watchDataTable = "#watchDataTable";
            static readonly watchDataTableBody = "#watchDataTableBody";
        }
        export class LocalStorage{
            static readonly tokenKey: string = "watchListSecureToken";
        }
        export class WebAPIURL{
            static readonly authUrl: string = "http://localhost:89/WatchListAPI/Auth/Login";
            static readonly getWatchDataUrl: string = "http://localhost:89/WatchListAPI/WatchData/Get";
        }
        export class Value {
            static readonly MaxReview: number = 5;
        }
    }
}