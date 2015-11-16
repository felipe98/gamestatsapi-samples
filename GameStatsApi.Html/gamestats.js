var gameStatsApi = function () {
    var self = this;

    self.apiKey = '';
    self.apiToken = '';
    self.useJquery = false;
    self.baseUrl = 'https://gamestatsapi.com/';

};

gameStatsApi.prototype = {
    init: function (key, token) {
        self.apiKey = key;
        self.apiToken = token;

        if (typeof jQuery === 'undefined') { } else {
            self.useJquery = true;
        }
    },
    debugOutput: function () {
        alert(self.apiKey + ' - ' + self.apiToken);
    },
    areaEvent: function (area, callback) {
        this.postHelper(this.baseUrl + 'api/events/area' + this.getAuth(), JSON.stringify(area), callback);
    },
    generalEvent: function (general, callback) {
        this.postHelper(this.baseUrl + 'api/events/general' + this.getAuth(), JSON.stringify(general), callback);
    },
    downloadedEvent: function (downloaded, callback) {
        this.postHelper(this.baseUrl + 'api/events/downloaded' + this.getAuth(), JSON.stringify(downloaded), callback);
    },
    capture: function(snapshot, callback){
        this.postHelper(this.baseUrl + 'api/events/capture' + this.getAuth(), JSON.stringify(snapshot), callback);
    },
    getAuth: function () {
        return '?apikey=' + self.apiKey + '&token=' + self.apiToken;
    },
    postHelper: function (url, data, callback) {
        try{
            if (self.useJquery) {
                $.ajax({
                    url: url,
                    beforeSend: function (request) {
                        request.setRequestHeader("Access-Control-Allow-Origin", "*");
                    },
                    type: 'POST',
                    data: data,
                    dataType: 'json',
                    contentType: 'application/json',
                    success: function (data) {
                        if (callback) {
                            callback(data);
                        }
                    },
                    error: function (e) {
                        alert(JSON.stringify(e));
                    }
                });
            } else {
                var xmlhttp = new XMLHttpRequest();

                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4) {
                        if (xmlhttp.status == 200) {
                            if (callback) {
                                callback(JSON.parse(xmlhttp.responseText));
                            }
                        }
                    }
                }

                xmlhttp.open('POST', url, true);
                xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                xmlhttp.send(data);
            }
        }
        catch (exception) {
            alert(exception);
        }
    }
};

var Area = function () {
    var self = this;

    self.Meta = '';
    self.Platform = '';
    self.PlayerId = '';
    self.ProjectId = '';
    self.Area = '';
    self.Difficulty = '';
    self.PerctCompleted = 0;
};

var General = function () {
    var self = this;

    self.Meta = '';
    self.Platform = '';
    self.PlayerId = '';
    self.ProjectId = '';
    self.AreaName = '';
    self.Difficulty = '';
    self.PerctCompleted = 0;
    self.TotalHours = 0;
};

var Downloaded = function () {
    var self = this;

    self.Meta = '';
    self.Platform = '';
    self.PlayerId = '';
    self.ProjectId = '';
}

var Snapshot = function () {
    var self = this;

    self.Platform = '';
    self.PlayerId = '';
    self.IsPublic = true;
    self.Data = ''; // Image bytes encoded as a base64 string.
};

var ResponseObject = function () {
    var self = this;

    this.errors = [];
    this.meta = '';
    this.message = '';

};