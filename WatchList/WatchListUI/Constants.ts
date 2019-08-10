module WatchListConstants {
    export module ControlConstants {
        export class Selector{
            static readonly userID: string = "#uid";
            static readonly pass: string = "#pass"
        }
        export class WebAPIURL{
            static readonly authUrl: string = "http://localhost:89/WatchListAPI/Auth/Login";
            static readonly getWatchData: string = "http://localhost:89/WatchListAPI/WatchData/Get?uid=";
        }
    }
}