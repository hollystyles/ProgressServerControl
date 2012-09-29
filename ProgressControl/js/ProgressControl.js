var progressControls = [];

setInterval(pollProgress, 2000);

function pollProgress() {
    for (var i = 0; i < progressControls.length; i++) {
        sendRequest('poll.progress?k=' + progressControls[i], receiveProgress);
    }
}

function receiveProgress(response) {
    
    eval('var progress = ' + response.response);

    for (var i = 0; i < progress.length; i++) {
        for (var j = 0; j < progressControls.length; j++) {
            if (progressControls[j] == progress[i].Key) {
                var progEl = document.getElementById(progressControls[j])
                var progressVal = (progress[i].Count / progress[i].Total) * 100 + '%';
                progEl.firstChild.style.width = progressVal;
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

var XMLHttpFactories = [
    function () { return new XMLHttpRequest() },
    function () { return new ActiveXObject("Msxml2.XMLHTTP") },
    function () { return new ActiveXObject("Msxml3.XMLHTTP") },
    function () { return new ActiveXObject("Microsoft.XMLHTTP") }
];

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