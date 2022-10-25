
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

//recibing data from Hub
connectionUserCount.on("updateTotalViews", (value) => {
    console.log("New data:" + value);
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerHTML = value;
});

//sending data from client
function newWindowLoaded() {
    connectionUserCount.send("NewWindowLoaded");
}

function onSuccess() {
    console.log("Connection successful");
    newWindowLoaded();
}

function onFailure() {
    console.log("Error on connection");
}

connectionUserCount.start().then(onSuccess, onFailure);