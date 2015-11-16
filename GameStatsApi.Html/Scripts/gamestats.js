var Endpoints = {
    General: { url: 'api/events/general' },
    Custom: { url: 'api/events/custom' },
    Downloaded: { url: 'api/events/downloaded' },
    CaptureSnapshot: { url: 'api/media/capture' },
    CaptureSequence: { url: 'api/media/capturesequence' },
    TopSnapshots: { url: 'api/media/selecttop' },
    AchievementUnlock: { url: 'api/achievement/unlock' },
    AchievementTimeline: { url: 'api/achievement/timeline' }
};
var GameStatsApi = function () {
    this.apiKey = '';
    this.apiToken = '';
    this.useJquery = false;
    this.baseUrl = 'https://gamestatsapi.com/';

    if (typeof jQuery === 'undefined') { } else {
        this.useJquery = true;
    }

    // Actions
    this.getAuth = function () {
        return '?apikey=' + this.apiKey + '&token=' + this.apiToken;
    };
    this.postHelper = function (url, data, callback) {
        try {
            if (this.useJquery) {
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
    };
    this.getHelper = function (url, callback) {
        try {
            if (this.useJquery) {
                $.ajax({
                    url: url,
                    beforeSend: function (request) {
                        request.setRequestHeader("Access-Control-Allow-Origin", "*");
                    },
                    type: 'GET',
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

                xmlhttp.open('GET', url, true);
                xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                xmlhttp.send();
            }
        }
        catch (exception) {
            alert(exception);
        }
    };
};
GameStatsApi.prototype = {
    init: function (key, token) {
        this.apiKey = key;
        this.apiToken = token;
    },
    record: function (url, data, callback) {
        this.postHelper(this.baseUrl + url + this.getAuth(), JSON.stringify(data), callback);
    },
    persistSequence: function (data, callback) {
        this.record(Endpoints.CaptureSequence.url, data, callback);
    },
    persistSnapshot: function (data, callback) {
        this.record(Endpoints.CaptureSnapshot.url, data, callback);
    },
    downloaded: function (data, callback) {
        this.record(Endpoints.Downloaded.url, data, callback);
    },
    general: function (data, callback) {
        this.record(Endpoints.General, data, callback);
    },
    custom: function (data, callback) {
        this.record(Endpoints.Custom, data, callback);
    },
    achievementUnlock: function (data, callback) {
        this.record(Endpoints.AchievementUnlock.url, data, callback);
    },
    achievementTimeline: function (projectId, callback) {
        this.getHelper(this.baseUrl + Endpoints.AchievementTimeline.url + this.getAuth() + '&projectId=' + projectId, callback);
    },
    topSnapshots: function (projectId, callback) {
        this.getHelper(this.baseUrl + Endpoints.TopSnapshots.url + this.getAuth() + '&projectId=' + projectId, callback);
    }
};

// Models
var Area = function () {
    var self = this;

    this.Meta = '';
    this.Platform = '';
    this.PlayerId = '';
    this.ProjectId = '';
    this.Area = '';
    this.Difficulty = '';
    this.PerctCompleted = 0;
};
var General = function () {
    var self = this;

    this.Meta = '';
    this.Platform = '';
    this.PlayerId = '';
    this.ProjectId = '';
    this.AreaName = '';
    this.Difficulty = '';
    this.PerctCompleted = 0;
    this.TotalHours = 0;
};
var Downloaded = function () {
    this.Meta = '';
    this.Platform = '';
    this.PlayerId = '';
    this.ProjectId = '';
};
var Achievement = function () {
    this.Meta = '';
    this.PlayerId = '';
    this.ProjectId = '';
};
var Snapshot = function () {
    this.ProjectId = -1;
    this.Platform = '';
    this.PlayerId = '';
    this.IsPublic = true;
    this.Data = ''; // Image bytes encoded as a base64 string.
};
var ResponseObject = function () {
    var self = this;

    this.errors = [];
    this.meta = '';
    this.message = '';

};
var SequenceHelper = function () {
    this.currentFrame = 0;
    this.frameLimit = 25;
    this.sequence = new Array(this.frameLimit);
    this.sequenceWrapped = false;
    this.elapsed = 0
    this.last = null
    this.meta = '';

    this.setFrameReady = function () {
        var now = new Date();
        var milli = (now.getTime() - this.last.getTime());

        this.elapsed += milli;

        return this.elapsed > (1000 / 12);
    };
    this.buildSequenceJson = function () {
        var seq = new Array();
        try {
            if (this.sequenceWrapped == true) {
                for (var i = (this.frameLimit - this.currentFrame - 1) ; i < this.frameLimit; i++) {
                    if (this.sequence[i]) {
                        seq.push(this.sequence[i]);
                    }
                }

                for (var i = 0; i < (this.currentFrame - 1) ; i++) {
                    if (this.sequence[i]) {
                        seq.push(this.sequence[i]);
                    }
                }
            } else {
                for (var i = 0; i < this.frameLimit; i++) {
                    if (this.sequence[i]) {
                        seq.push(this.sequence[i]);
                    }
                }
            }
        }
        catch (ex) {
            alert(ex);
        }


        var data = {
            SequenceData: seq,
            Meta: this.meta,
            PlayerId: 'felipe.ramos@unlimited-software.com',
            ProjectId: 1
        };

        return data;
    };
};
function setFrame(helper, frameData) {
    if (helper.last == null) { helper.last = new Date(); }
    var now = new Date();
    var milli = (now.getTime() - helper.last.getTime());

    helper.elapsed += milli;

    if (helper.elapsed > (1000 / 12)) {
        helper.elapsed -= (1000 / 12);

        if (helper.currentFrame > helper.frameLimit) {
            helper.currentFrame = 0;
            helper.sequenceWrapped = true;
        }

        helper.sequence[helper.currentFrame] = frameData;
        helper.currentFrame += 1;
    }

    helper.last = now;
};

// Models Prototypes
Snapshot.prototype = {
    create: function (projectId, playerId, data, platform, isPublic) {
        this.ProjectId = projectId;
        this.Platform = platform;
        this.PlayerId = playerId;
        this.IsPublic = isPublic;
        this.Data = data
    }
};