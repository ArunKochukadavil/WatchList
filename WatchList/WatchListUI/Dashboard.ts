/// <reference path="Constants.ts"/>
/// <reference path="Models/Result.ts"/>
/// <reference path="Models/WatchData.ts"/>
class Dashboard {
    init(): void {
        this.fetchWatchListData();
        this.initializeEvents();
        Dashboard.watchDataTableBody = $(WatchListConstants.ControlConstants.Selector.watchDataTableBody)[0];
    }
    static result: Result;
    static watchDataTableBody: any;

    static populateTable(watchData: WatchData[]): void {
        console.log(watchData);
        $(WatchListConstants.ControlConstants.Selector.watchDataTableBody).empty();
        for (var i = 0; i < watchData.length; i++) {
            let newRow = Dashboard.watchDataTableBody.insertRow();
            let newCell = newRow.insertCell();
            newCell.id = watchData[i].ID;
            newCell.innerText = watchData[i].Name;

            newCell = newRow.insertCell();
            newCell.innerText = watchData[i].Genre;

            newCell = newRow.insertCell();
            newCell.innerText = watchData[i].Season;

            newCell = newRow.insertCell();
            newCell.innerText = watchData[i].EpisodesCompleted;

            newCell = newRow.insertCell();
            newCell.innerText = watchData[i].TotalEpisodes;

            newCell = newRow.insertCell();
            newCell.innerText = watchData[i].Status;

            newCell = newRow.insertCell();
            for (var j = 0; j < WatchListConstants.ControlConstants.Value.MaxReview; j++) {
                var reviewElement = document.createElement('span');
                if (j < watchData[i].Reviews) {
                    reviewElement.className = "fa fa-star checked";
                }
                else {
                    reviewElement.className = "fa fa-star";
                }
                newCell.append(reviewElement);
            }

            newCell = newRow.insertCell();
            newCell.innerText = watchData[i].DownloadLinks;

            newCell = newRow.insertCell();
            var checkBoxForSharing = document.createElement('input');
            checkBoxForSharing.setAttribute("type", "checkbox");
            newCell.append(checkBoxForSharing);
        }
    }

    fetchWatchListData(): void {
        var apiUrl: string = WatchListConstants.ControlConstants.WebAPIURL.getWatchDataUrl;
        var request: JQueryAjaxSettings = {};
        request.url = apiUrl;
        request.method = "GET";
        request.dataType = "json";
        request.cache = false;
        request.beforeSend = function (xhr) {
            /* Authorization header */
            xhr.setRequestHeader("Authorization", "Basic " + localStorage.getItem(WatchListConstants.ControlConstants.LocalStorage.tokenKey));
        };
        request.success = function (data) {
            Dashboard.result = data;
            let watchData: WatchData[] = data.Data;
            if (Dashboard.result.IsSucceed) {
                Dashboard.populateTable(watchData);
            }
            else {
                window.location.href = "Index.html";
            }
        };
        request.error = function (jqXHR, textStatus, errorThrown) {
            alert("It seems that you are no more logged in")
            window.location.href = "Index.html";
        };
        $.ajax(request);
    }

    initializeEvents(): void {
        $(WatchListConstants.ControlConstants.Selector.signOut).bind('click', function () {
            localStorage.removeItem(WatchListConstants.ControlConstants.LocalStorage.tokenKey);
            window.location.href = "Index.html";
        });
    }
}