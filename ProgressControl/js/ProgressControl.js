var progressControls = [];
var pollIntervalId = setInterval(pollProgress, 2000);
var emptyCount = 0;
var XMLHttpFactories = [
    function () { return new XMLHttpRequest() },
    function () { return new ActiveXObject("Msxml2.XMLHTTP") },
    function () { return new ActiveXObject("Msxml3.XMLHTTP") },
    function () { return new ActiveXObject("Microsoft.XMLHTTP") }
];

function pollProgress() {
    for (var i = 0; i < progressControls.length; i++) {
        sendRequest('poll.progress', receiveProgress);
    }
}

function receiveProgress(response) {
    
    eval('var progress = ' + response.response);

    if (progress.length == 0) {
        if (emptyCount > 3) {
            window.clearInterval(pollIntervalId);
        } else {
            emptyCount++;
        }
    } else {
        for (var i = 0; i < progress.length; i++) {

            for (var j = 0; j < progressControls.length; j++) {

                if (progressControls[j] == progress[i].Key) {

                    var progEvt = progress[i];
                    var progEl = document.getElementById(progressControls[j]);
                    var progVal = (progEvt.Count / progEvt.Total) * 100;

                    progEl.firstChild.style.width = progVal + '%';

                    if (progEvt.Count == progEvt.Total) {
                        window.clearInterval(pollIntervalId);
                    }
                }
            }
        }
    }
}

function sendRequest(url, callback, postData) {
    var req = createXMLHTTPObject();
    if (!req) return;
    var method = (postData) ? "POST" : "GET";
    req.open(method, url, true);;
    if (postData)
        req.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    req.onreadystatechange = function () {
        if (req.readyState != 4) return;
        if (req.status != 200 && req.status != 304) {
            return;
        }
        callback(req);
    }
    if (req.readyState == 4) return;
    req.send(postData);
}

function createXMLHTTPObject() {
    var xmlhttp = false;
    for (var i = 0; i < XMLHttpFactories.length; i++) {
        try {
            xmlhttp = XMLHttpFactories[i]();
        }
        catch (e) {
            continue;
        }
        break;
    }
    return xmlhttp;
}